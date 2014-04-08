using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SSZClient.Callback;
using SSZClient.CardRecognizeServiceReference;
using SSZClient.CardTypeParseServiceReference;
using SSZClient.GameControlServiceReference;

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

        //十三张手牌区域
        private readonly Rectangle _rectSsz = new Rectangle(290, 510, 300, 50);

        //其他友方牌型分析结果
        private readonly List<CardTypeResult> _friendCardTypeResults = new List<CardTypeResult>();

        public Form1()
        {
            InitializeComponent();

            //开始识别牌事件处理函数
            _controlCallback.StartRecognize += args =>
            {
                
            };

            //有数据广播事件处理函数
            _controlCallback.Broadcast += args =>
            {

            };

            _proxyControl = new GameControlServiceClient(new InstanceContext(_controlCallback));
            _proxyControl.Connect(new ClientInfo
            {
                PlayerName = "当前客户端游戏名"
            });
        }
    }
}
