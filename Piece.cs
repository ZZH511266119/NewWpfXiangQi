using System;
using System.Collections.Generic;
using System.Text;

namespace WpfProject
{
    public abstract class Piece
    {
        string name;//名字，颜色，行，列，这是我暂时想到有用的属性
        public int column;
        public int row;
        public string color;
        public bool canGo = false;
        public bool alive = true;
        public bool beProtected = false;
        public string image;
        public string imageEat;

        public Piece(string color, string name, int column, int row)//构造函数
        {
            this.color = color;
            this.name = name;
            this.column = column;
            this.row = row;
        }

        public string GetName()//获取名字
        {
            return this.name;
        }

        public string GetColor()//获取棋子的颜色
        {
            return this.color;
        }

        public bool GetCanGo()
        {
            return this.canGo;
        }

        public bool GetAlve()
        {
            return this.alive;
        }

        public void SetName(string name)//获取名字
        {
            this.name = name;
        }

        public void SetColor(string color)//获取棋子的颜色
        {
             this.color = color;
        }

        public void ChangeCanGo()
        {
             this.canGo = true;
        }

        public string GetImage()
        {
            return this.image;
        }

        public string GetImageEat()
        {
            return this.imageEat;
        }


    }
    public class horse : Piece
    {
        public horse(string color, int column, int row)
        : base(color, "马", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/Rh.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/RhS.gif";
                    break;

                case "black":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/Bh.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/BhS.gif";
                    break;
            }
        }
    }

    public class cannon : Piece
    {
        public cannon(string color, int column, int row)
        : base(color, "炮", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/Rc.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/RcS.gif";
                    break;

                case "black":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/Bc.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/BcS.gif";
                    break;
            }
        }
    }
    
    public class rood : Piece
    {
        public rood(string color, int column, int row)
        : base(color, "车", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/Rr.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/RrS.gif";
                    break;

                case "black":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/Br.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/BrS.gif";
                    break;
            }
        }
    }

    public class soldier : Piece
    {
        public soldier(string color, int column, int row)
        : base(color, "兵", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/Rs.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/RsS.gif";
                    break;

                case "black":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/Bs.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/BsS.gif";
                    break;
            }
        }

    }

    public class elephant : Piece
    {
        public elephant(string color, int column, int row)
        : base(color, "象", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/Re.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/ReS.gif";
                    break;

                case "black":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/Be.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/BeS.gif";
                    break;
            }
        }
    }

    public class guard : Piece
    {
        public guard(string color, int column, int row)
        : base(color, "士", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/Rg.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/RgS.gif";
                    break;

                case "black":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/Bg.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/BgS.gif";
                    break;
            }
        }
    }

    public class general : Piece
    {
        public general(string color, int column, int row)
            : base(color, "将", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/RK.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/RKS.gif";

                    break;

                case "black":
                    this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/BK.gif";
                    this.imageEat = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/BKS.gif";
                    break;
            }
        }
    }

    public class nochess : Piece
    {
        public nochess(int column, int row)
            : base("nochess", "nochess", column, row)
        { this.image = "C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/OO.gif"; }
    }
}