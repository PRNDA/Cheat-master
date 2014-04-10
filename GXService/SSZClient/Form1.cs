using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using SSZClient.Callback;
using SSZClient.CardRecognizeServiceReference;
using SSZClient.CardTypeParseServiceReference;
using SSZClient.GameControlServiceReference;
using GXService.Utils;
using CardTypeResult = SSZClient.CardTypeParseServiceReference.CardTypeResult;
using RecognizeResult = SSZClient.CardRecognizeServiceReference.RecognizeResult;

namespace SSZClient
{
    public partial class Form1 : Form
    {
        private readonly CardsRecognizerClient _proxyRecognize = new CardsRecognizerClient();
        private readonly CardTypeParseServiceClient _proxyParse = new CardTypeParseServiceClient();
        private readonly GameControlServiceClient _proxyControl;
        private readonly GameControlServiceCallback _controlCallback = new GameControlServiceCallback();

        //头墩、中墩、尾墩牌框中心点
        private readonly Point _headCenterPoint = new Point(500, 270);
        private readonly Point _bodyCenterPoint = new Point(480, 370);
        private readonly Point _tailCenterPoint = new Point(440, 460);

        //最大玩家个数
        private const int MaxPlayers = 3;

        //十三张手牌区域
        private readonly Rectangle _rectSsz = new Rectangle(290, 510, 300, 50);

        //其他友方牌识别结果
        private readonly List<ClientContext> _friendRecognizedResults = new List<ClientContext>();

        //当前用户的牌识别结果
        private RecognizeResult _recognizeResult = null;

        //当前用户牌型分析结果
        private CardTypeResult _cardTypeResult = null;

        //游戏上下文
        private readonly GameContext _gameContext = new GameContext("thirtn");

        //当前客户端信息
        private readonly ClientInfo _clientInfo = new ClientInfo
        {
            PlayerName = "当前客户端游戏名"
        };

        //是否已经开始识别
        private bool _isStartRecognized = false;

        public Form1()
        {
            InitializeComponent();

            //开始识别牌事件处理函数
            _controlCallback.StartRecognize += args => Recognize();

            //其他客户端识别完成事件处理函数
            _controlCallback.Recognized += args =>
            {
                if (!_friendRecognizedResults.Exists(r => r.ClientInfo.PlayerName == args.ClientInfo.PlayerName))
                {
                    _friendRecognizedResults.Add(new ClientContext(args.ClientInfo, args.RecognizeResult));    
                }
                
                if (_friendRecognizedResults.Count >= MaxPlayers)
                {
                    //其他所有玩家牌都识别完成则进行牌型分析并自动出牌比牌
                    AutoPlay();
                }
            };

            //创建游戏控制服务代理，并连接服务
            _proxyControl = new GameControlServiceClient(new InstanceContext(_controlCallback));
            _proxyControl.Connect(_clientInfo);

            _proxyRecognize.Start();
            _proxyParse.Connect();
        }

        /// <summary>
        /// 识别牌，此函数可手动触发也可事件触发，故增加一个状态避免重复执行此函数
        /// </summary>
        private void Recognize()
        {
            //如果已经开始识别了，则不能再次识别
            if (_isStartRecognized)
            {
                return;
            }

            //设置标志为已经开始识别
            _isStartRecognized = true;

            //截取游戏窗口
            var bmp = _gameContext.Capture();

            //识别扑克牌
            _recognizeResult = _proxyRecognize.Recognize(new RecoginizeData
            {
                CardsBitmap = bmp.Clone(_rectSsz, bmp.PixelFormat).Serialize()
            });

            //识别完成，通知给其他客户端
            _proxyControl.Recognized(_clientInfo, _recognizeResult);
        }

        /// <summary>
        /// 自动出牌比牌
        /// </summary>
        private void AutoPlay()
        {
            //牌型分析
            CardTypeParse();

            //分析完成则根据分析的结果进行出牌
            ThrowHeadCards();
            ThrowMiddleCards();
            ThrowTailCards();

            //确认开始比牌型
            Confirm();

            //重置识别状态
            _isStartRecognized = false;
        }

        /// <summary>
        /// 解析牌型
        /// </summary>
        private void CardTypeParse()
        {
            _cardTypeResult = _proxyParse.ParseCardType(_recognizeResult.Result);
        }

        /// <summary>
        /// 根据头墩牌型进行出牌
        /// </summary>
        private void ThrowHeadCards()
        {
            _cardTypeResult.CardTypeHead
                    .Cards
                    .ToList()
                    .ForEach(card =>
                    {
                        var tmpRect = new Rectangle(new Point(card.Rect.X + _rectSsz.X, card.Rect.Y + _rectSsz.Y),
                            card.Rect.Size);

                        //将牌选出来
                        tmpRect.Center().MouseLClick(_gameContext.Wnd);
                    });

            //所有头墩牌被点出，需要点击头墩框，将牌放到头墩框中
            _headCenterPoint.MouseLClick(_gameContext.Wnd);
        }

        /// <summary>
        /// 根据中墩牌型进行出牌
        /// </summary>
        private void ThrowMiddleCards()
        {
            //需要重新获取当前牌并识别，因为头墩牌出了后，牌的位置会发生变化，需要重新获取牌的位置
            var bmp = _gameContext.Capture();

            //识别扑克牌
            var result = _proxyRecognize.Recognize(new RecoginizeData
            {
                CardsBitmap = bmp.Clone(_rectSsz, bmp.PixelFormat).Serialize()
            });

            _cardTypeResult.CardTypeMiddle
                .Cards
                .ToList()
                .ForEach(card =>
                {
                    var newCard = result.Result.FirstOrDefault(c => c.Num == card.Num && c.Color == card.Color);
                    if (newCard == null)
                    {
                        //如果第二次未找到牌型里的牌，说明牌识别有问题，理论上应该是可以识别到的
                        return;
                    }
                    var tmpRect = new Rectangle(new Point(newCard.Rect.X + _rectSsz.X, newCard.Rect.Y + _rectSsz.Y),
                        newCard.Rect.Size);

                    //将牌选出来
                    tmpRect.Center().MouseLClick(_gameContext.Wnd);
                });

            //所有中墩牌被点出，需要点击中墩框，将牌放到中墩框中
            _bodyCenterPoint.MouseLClick(_gameContext.Wnd);
        }

        /// <summary>
        /// 根据尾墩牌型进行出牌
        /// </summary>
        private void ThrowTailCards()
        {
            //需要重新获取当前牌并识别，因为中墩牌出了后，牌的位置会发生变化，需要重新获取牌的位置
            var bmp = _gameContext.Capture();

            //识别扑克牌
            var result = _proxyRecognize.Recognize(new RecoginizeData
            {
                CardsBitmap = bmp.Clone(_rectSsz, bmp.PixelFormat).Serialize()
            });

            _cardTypeResult.CardTypeTail
                .Cards
                .ToList()
                .ForEach(card =>
                {
                    var newCard = result.Result.FirstOrDefault(c => c.Num == card.Num && c.Color == card.Color);
                    if (newCard == null)
                    {
                        //如果第二次未找到牌型里的牌，说明牌识别有问题，理论上应该是可以识别到的
                        return;
                    }
                    var tmpRect = new Rectangle(new Point(newCard.Rect.X + _rectSsz.X, newCard.Rect.Y + _rectSsz.Y),
                        newCard.Rect.Size);

                    //将牌选出来
                    tmpRect.Center().MouseLClick(_gameContext.Wnd);
                });

            //所有尾墩牌被点出，需要点击尾墩框，将牌放到尾墩框中
            _tailCenterPoint.MouseLClick(_gameContext.Wnd);
        }

        /// <summary>
        /// 确认开始比牌型
        /// </summary>
        private void Confirm()
        {
            //需要获取比牌型的按钮坐标
            //todo
        }
    }
}
