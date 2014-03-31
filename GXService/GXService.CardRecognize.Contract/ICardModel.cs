using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Linq;

namespace GXService.CardRecognize.Contract
{

    //游戏类型
    public enum GameTemplateType
    {
        斗地主手牌 = 0,
        十三张 = 1,
        斗地主出牌 = 2
    }

    public enum CardNum
    {
        未知 = -1,
        _2 = 2,
        _3,
        _4,
        _5,
        _6,
        _7,
        _8,
        _9,
        _10,
        _J,
        _Q,
        _K,
        _A,
        _Joke,
        _BigJoke,
        _Any
    }

    public enum CardColor
    {
        未知 = -1,
        方块 = 0,
        梅花 = 1,
        红桃 = 2,
        黑桃 = 3
    }

    [DataContract(Namespace = "GXService.CardRecognize.Contract")]
    public class Card
    {
        [DataMember]
        public CardNum Num { get; set; }

        [DataMember]
        public CardColor Color { get; set; }

        [DataMember]
        public Rectangle Rect { get; set; }
        
        public override string ToString()
        {
            return "{" + Color + "," + Num + "}";
        }

        public static bool operator >=(Card c1, Card c2)
        {
            var ret = true;

            if (c1.Num < c2.Num)
            {
                ret = false;
            }
            else if (c1.Num == c2.Num && c1.Color < c2.Color)
            {
                ret = false;
            }

            return ret;
        }

        public static bool operator <=(Card c1, Card c2)
        {
            var ret = true;

            if (c1.Num > c2.Num)
            {
                ret = false;
            }
            else if (c1.Num == c2.Num && c1.Color > c2.Color)
            {
                ret = false;
            }

            return ret;
        }
    }
}
