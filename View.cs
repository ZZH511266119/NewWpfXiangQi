using System;

namespace WpfProject
{
    public class View
    {
        public Controller game = new Controller();
        string[,] displayBoard = new string[11, 10];
        int[] beginPoint;

        public void PlayerChoose(int row,int col)//选择棋子
        {
            int[] beginPointInt = new int[2];
            beginPointInt[0] = row;
            beginPointInt[1] = col;
            game.FindBigningPointException(beginPointInt);

            game.controller.WhereCanPieceGo(beginPointInt[1], beginPointInt[0]);

            this.beginPoint = beginPointInt;
        }

        public void PlayerMove(int row, int col)
        {
            int[] endPointInt = new int[2];
            endPointInt[0] = row;
            endPointInt[1] = col;
            game.FindEndingPointException(endPointInt, this.beginPoint);

            game.GeneralDie(endPointInt);
            game.ChooseAndMove(this.beginPoint[0], this.beginPoint[1], endPointInt[0], endPointInt[1]);
            game.EmptyCanGo(game.controller);
        }

        public void AIinput()
        {
            int[] BestMove = game.FindtheBestPoint();

            game.ChooseAndMove(BestMove[0], BestMove[1], BestMove[2], BestMove[3]);
            game.EmptyCanGo(game.controller);
        }
    }
}
