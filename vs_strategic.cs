using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PenguinParty
{
    class Player
    {
        public int green = 0;
        public int yellow = 0;
        public int red = 0;
        public int purple = 0;
        public int blue = 0;
        public int winc=0;
        public float point = 0;
        public int Max=14;
        public int[] a_sort = new int[5];
        int[] colorsort = new int[5];
        public int mode = 0;
        public int loseturn = 0;
        int i = 0;
        public void priority()
        {
            colorsort[0] = green;
            colorsort[1] = yellow;
            colorsort[2] = red;
            colorsort[3] = purple;
            colorsort[4] = blue;
            Array.Sort(colorsort);
            for (i = 0; i < 5; i++)
            {
                if (colorsort[i] == green) a_sort[i] = 1;
                if (colorsort[i] == yellow) a_sort[i] = 2;
                if (colorsort[i] == red) a_sort[i] = 3;
                if (colorsort[i] == purple) a_sort[i] = 4;
                if (colorsort[i] == blue) a_sort[i] = 5;
            }
        }
        public void reset()
        {
            green = 0;
            yellow = 0;
            red = 0;
            purple = 0;
            blue = 0;
        }
        public void Maxcount()
        {
            if (Max > Hand(0))
            {
                Max = Hand(0);
            }
        }
        public int Hand(int s)
        {
           // s = 0;
           if (s == 1)
            {
                Console.Write("緑:"); Console.Write(green); Console.Write("黄:"); Console.Write(yellow);
                Console.Write("赤:"); Console.Write(red); Console.Write("紫:"); Console.Write(purple);
                Console.Write("青:"); Console.WriteLine(blue);
            }
            return (green + yellow + red + purple + blue);
        }


    }

    class FieldData
    {
        public int[] card = new int[29];//エラー対策で多めに
        public int green = 8;
        public int yellow = 7;
        public int red = 7;
        public int purple = 7;
        public int blue = 7;
        public void reset()
        {
            int i = 0;
            for (i = 0; i < 28; i++) card[i] = 0;
            green = 8;
            yellow = 7;
            red = 7;
            purple = 7;
            blue = 7;
    }

        public bool Deploy(int color, int area)
        {
            card[area - 1] = color;
            Console.WriteLine(area +"に設置成功:"+ color);
            return (true);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Player P1 = new Player();
            Player P2 = new Player();
            FieldData play = new FieldData();
            Random r = new System.Random();
            int N = 1;
            int coin = 1;
            int stage = 0;
            int turn = 1;
            int i;
            int x = 7;
            int p_c = 0;
            int draw = 0;
            bool randroop = true;
            bool roop = true;
            bool green_c = false;
            bool yellow_c = false;
            bool red_c = false;
            bool purple_c = false;
            bool blue_c = false;
            bool ex = false;
            int drawscore = 0;
            int k = 0;
            int t = 0;
            int ec = 0;
            int AI = 0;
            int aturn = 0;
            int bturn = 0;
            void refresh()
            {
                green_c = false;
                yellow_c = false;
                red_c = false;
                purple_c = false;
                blue_c = false;
                ex = false;
                x = 7;
                p_c = 0;
            }

            int area = 0;
            int color = 0;
            Console.WriteLine("ペンギンパーティーを開始します");
            Console.Write("試行回数を入力:");
            N = int.Parse(Console.ReadLine());
            Console.Write("先攻の番号を入力:");
            coin = int.Parse(Console.ReadLine());
            Console.Write("P2を自分で操作する場合は0、ランダム戦略AIにする場合は1、自作戦略にする場合は2を入力:");
            AI = int.Parse(Console.ReadLine());
            if (AI != 0 && AI != 1) AI = 1;
            for (t = 0; t < N; t++)
            {
                roop = true;
                turn= 1;
                play.reset();
                P1.reset();
                P2.reset();
                P1.loseturn = 0;
                P2.loseturn = 0;
                /*手札配布フェーズ*/
                Console.WriteLine("P1の手札");
                while (P1.Hand(0) < 14)
                {
                    switch (r.Next(1, 6))
                    {
                        case 1:
                            if (play.green > 0)
                            {
                                P1.green++;
                                play.green--;
                            }
                            break;
                        case 2:
                            if (play.yellow > 0)
                            {
                                P1.yellow++;
                                play.yellow--;
                            }
                            break;
                        case 3:
                            if (play.red > 0)
                            {
                                P1.red++;
                                play.red--;
                            }
                            break;
                        case 4:
                            if (play.purple > 0)
                            {
                                P1.purple++;
                                play.purple--;
                            }
                            break;
                        case 5:
                            if (play.blue > 0)
                            {
                                P1.blue++;
                                play.blue--;
                            }

                            break;
                    }

                }
                Console.WriteLine("P2の手札");
                while (P2.Hand(0) < 14)
                {
                    switch (r.Next(1, 6))
                    {
                        case 1:
                            if (play.green > 0)
                            {
                                P2.green++;
                                play.green--;
                            }
                            break;
                        case 2:
                            if (play.yellow > 0)
                            {
                                P2.yellow++;
                                play.yellow--;
                            }
                            break;
                        case 3:
                            if (play.red > 0)
                            {
                                P2.red++;
                                play.red--;
                            }
                            break;
                        case 4:
                            if (play.purple > 0)
                            {
                                P2.purple++;
                                play.purple--;
                            }
                            break;
                        case 5:
                            if (play.blue > 0)
                            {
                                P2.blue++;
                                play.blue--;
                            }
                            break;
                    }

                }
                /*ゲーム開始*/
                while (P1.loseturn==0||P2.loseturn==0)
                {
                    /*P1のターン*/
                    if (P1.loseturn==0&&!(coin==2&&turn==1))
                    {
                        randroop = true;
                        Console.WriteLine("P1のターン");
                        P1.Hand(0);
                        {
                            /* 敗北判定 */

                            refresh();
                            for (i = 21; i <= 27; i++)
                            {

                                if (play.card[i] == 0 && P1.Hand(0) != 0)
                                {
                                    ex = true;
                                    break;
                                }

                            }
                            for (i = 27; 0 < i; i--)
                            {
                                if (i == 27 || i == 20 || i == 14 || i == 9 || i == 5 || i == 3)
                                {
                                    if (play.card[i] == 1 && play.card[i - 1] != 0 && play.card[i - x] == 0)
                                    {
                                        green_c = true;
                                    }
                                    if (play.card[i] == 2 && play.card[i - 1] != 0 && play.card[i - x] == 0)
                                    {
                                        yellow_c = true;
                                    }
                                    if (play.card[i] == 3 && play.card[i - 1] != 0 && play.card[i - x] == 0)
                                    {
                                        red_c = true;
                                    }
                                    if (play.card[i] == 4 && play.card[i - 1] != 0 && play.card[i - x] == 0)
                                    {
                                        purple_c = true;
                                    }
                                    if (play.card[i] == 5 && play.card[i - 1] != 0 && play.card[i - x] == 0)
                                    {
                                        blue_c = true;
                                    }
                                    x = x - 1;
                                }
                                else if (i == 21 || i == 15 || i == 10 || i == 6 || i == 3 || i == 1)
                                {
                                    if (play.card[i] == 1 && play.card[i + 1] != 0 && play.card[i - x] == 0)
                                    {
                                        green_c = true;
                                    }
                                    if (play.card[i] == 2 && play.card[i + 1] != 0 && play.card[i - x] == 0)
                                    {
                                        yellow_c = true;
                                    }
                                    if (play.card[i] == 3 && play.card[i + 1] != 0 && play.card[i - x] == 0)
                                    {
                                        red_c = true;
                                    }
                                    if (play.card[i] == 4 && play.card[i + 1] != 0 && play.card[i - x] == 0)
                                    {
                                        purple_c = true;

                                    }
                                    if (play.card[i] == 5 && play.card[i + 1] != 0 && play.card[i - x] == 0)
                                    {
                                        blue_c = true;
                                    }
                                }
                                else
                                {
                                    if (play.card[i] == 1 && ((play.card[i + 1] != 0 && play.card[i - x] == 0) || (play.card[i - 1] != 0 && play.card[i - x - 1] == 0)))
                                    {
                                        green_c = true;
                                    }
                                    if (play.card[i] == 2 && ((play.card[i + 1] != 0 && play.card[i - x] == 0) || (play.card[i - 1] != 0 && play.card[i - x - 1] == 0)))
                                    {
                                        yellow_c = true;
                                    }
                                    if (play.card[i] == 3 && ((play.card[i + 1] != 0 && play.card[i - x] == 0) || (play.card[i - 1] != 0 && play.card[i - x - 1] == 0)))
                                    {
                                        red_c = true;
                                    }
                                    if (play.card[i] == 4 && ((play.card[i + 1] != 0 && play.card[i - x] == 0) || (play.card[i - 1] != 0 && play.card[i - x - 1] == 0)))
                                    {
                                        purple_c = true;
                                    }
                                    if (play.card[i] == 5 && ((play.card[i + 1] != 0 && play.card[i - x] == 0) || (play.card[i - 1] != 0 && play.card[i - x - 1] == 0)))
                                    {
                                        blue_c = true;
                                    }
                                }
                            }
                            if (!ex && !((green_c && P1.green > 0) || (yellow_c && P1.yellow > 0) || (red_c && P1.red > 0) || (purple_c && P1.purple > 0) || (blue_c && P1.blue > 0)))
                            {
                                Console.WriteLine("もう置けません");
                                P1.loseturn=turn;
                                continue;
                            }
                            P1.priority();
                            for (x = 22; x <= 28; x++)
                            {
                                if (play.card[x - 1] == P1.a_sort[4]) p_c++;
                            }
                            while (randroop)
                            {
                                area = r.Next(0, 28) + 1;
                                color = r.Next(1, 6);
                                /*ランダム用*/
                                while (turn == 1 && area < 22)
                                {
                                    area = r.Next(21, 28) + 1;
                                }
                                /*エラー対策*/
                                k++;
                                if (k == 100000)
                                {
                                    Console.WriteLine("ERROR");
                                    ec++;
                                    t--;
                                    P2.loseturn = 1;
                                    P1.loseturn = 1;
                                    k = 0;
                                    break;
                                }
                                // Console.WriteLine(area + "を選出");
                                if (play.card[area - 1] == 0)
                                {
                                    /* 最下段の処理 */
                                    if (area == 22)
                                    {
                                        if (turn == 1)
                                        {
                                            while (roop)
                                            {
                                                Console.WriteLine("test");
                                                color = r.Next(1, 6);
                                                switch (color)
                                                {
                                                    case 1:
                                                        if (P1.green > 2)
                                                        {
                                                            roop = false;
                                                        }
                                                        break;
                                                    case 2:
                                                        if (P1.yellow > 2)
                                                        {
                                                            roop = false;
                                                        }
                                                        break;
                                                    case 3:
                                                        if (P1.red > 2)
                                                        {
                                                            roop = false;
                                                        }
                                                        break;
                                                    case 4:
                                                        if (P1.purple > 2)
                                                        {
                                                            roop = false;
                                                        }
                                                        break;
                                                    case 5:
                                                        if (P1.blue > 2)
                                                        {
                                                            roop = false;
                                                        }

                                                        break;
                                                }
                                                play.Deploy(color, area);
                                            }
                                            randroop = false;

                                        }
                                        else if (play.card[area] != 0)
                                        {
                                            if (ex && p_c < 2) color = P1.a_sort[4];
                                            switch (color)
                                            {
                                                case 1:
                                                    if (P1.green > 0)
                                                    {
                                                        P1.green--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 2:
                                                    if (P1.yellow > 0)
                                                    {
                                                        P1.yellow--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 3:
                                                    if (P1.red > 0)
                                                    {
                                                        P1.red--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 4:
                                                    if (P1.purple > 0)
                                                    {
                                                        P1.purple--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 5:
                                                    if (P1.blue > 0)
                                                    {
                                                        P1.blue--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }

                                                    break;
                                            }
                                        }
                                    }
                                    else if (22 < area && area <= 28)
                                    {
                                        if (turn == 1)
                                        {
                                            while (roop)
                                            {
                                                color = r.Next(1, 6);
                                                switch (color)
                                                {
                                                    case 1:
                                                        if (P1.green > 2)
                                                        {
                                                            roop = false;
                                                        }
                                                        break;
                                                    case 2:
                                                        if (P1.yellow > 2)
                                                        {
                                                            roop = false;
                                                        }
                                                        break;
                                                    case 3:
                                                        if (P1.red > 2)
                                                        {
                                                            roop = false;
                                                        }
                                                        break;
                                                    case 4:
                                                        if (P1.purple > 2)
                                                        {
                                                            roop = false;
                                                        }
                                                        break;
                                                    case 5:
                                                        if (P1.blue > 2)
                                                        {
                                                            roop = false;
                                                        }

                                                        break;
                                                }

                                            }
                                            play.Deploy(color, area);
                                            randroop = false;

                                        }
                                        else if (play.card[area - 2] != 0 || play.card[area] != 0)
                                        {
                                            if (p_c < 2) color = P1.a_sort[4];
                                            switch (color)
                                            {
                                                case 1:
                                                    if (P1.green > 0)
                                                    {
                                                        P1.green--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 2:
                                                    if (P1.yellow > 0)
                                                    {
                                                        P1.yellow--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 3:
                                                    if (P1.red > 0)
                                                    {
                                                        P1.red--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 4:
                                                    if (P1.purple > 0)
                                                    {
                                                        P1.purple--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 5:
                                                    if (P1.blue > 0)
                                                    {
                                                        P1.blue--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }

                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (area == 1) stage = 1;
                                        if (2 <= area && area <= 3) stage = 2;
                                        if (4 <= area && area <= 6) stage = 3;
                                        if (7 <= area && area <= 10) stage = 4;
                                        if (11 <= area && area <= 15) stage = 5;
                                        if (16 <= area && area <= 21) stage = 6;
                                        switch (color)
                                        {
                                            case 1:
                                                if (P1.green > 0 && ((play.card[area + stage - 1] == 1 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 1)))
                                                {
                                                    P1.green--;
                                                    play.Deploy(color, area);
                                                    randroop = false;
                                                }
                                                break;
                                            case 2:
                                                if (P1.yellow > 0 && ((play.card[area + stage - 1] == 2 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 2)))
                                                {
                                                    P1.yellow--;
                                                    play.Deploy(color, area);
                                                    randroop = false;
                                                }
                                                break;
                                            case 3:
                                                if (P1.red > 0 && ((play.card[area + stage - 1] == 3 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 3)))
                                                {
                                                    P1.red--;
                                                    play.Deploy(color, area);
                                                    randroop = false;
                                                }
                                                break;
                                            case 4:
                                                if (P1.purple > 0 && ((play.card[area + stage - 1] == 4 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 4)))
                                                {
                                                    P1.purple--;
                                                    play.Deploy(color, area);
                                                    randroop = false;
                                                }
                                                break;
                                            case 5:
                                                if (P1.blue > 0 && ((play.card[area + stage - 1] == 5 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 5)))
                                                {
                                                    P1.blue--;
                                                    play.Deploy(color, area);
                                                    randroop = false;
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        turn++;
                    }
                    /* P2のターン */
                    if (P2.loseturn==0)
                    {
                        randroop = true;
                        Console.WriteLine("P2のターン");
                        P2.Hand(AI+1);
                        {
                            /* 敗北判定 */
                            
                                refresh();
                                for (i = 21; i <= 27; i++)
                                {

                                    if (play.card[i] == 0&&P2.Hand(0)!=0)
                                    {
                                        ex = true;
                                        break;
                                    }

                                }
                                for (i = 27; 0 < i; i--)
                                {
                                    if (i == 27 || i == 20 || i == 14 || i == 9 || i == 5 || i == 3)
                                    {
                                        if (play.card[i] == 1 && play.card[i - 1] != 0 && play.card[i - x] == 0)
                                        {
                                            green_c = true;
                                        }
                                        if (play.card[i] == 2 && play.card[i - 1] != 0 && play.card[i - x] == 0)
                                        {
                                            yellow_c = true;
                                        }
                                        if (play.card[i] == 3 && play.card[i - 1] != 0 && play.card[i - x] == 0)
                                        {
                                            red_c = true;
                                        }
                                        if (play.card[i] == 4 && play.card[i - 1] != 0 && play.card[i - x] == 0)
                                        {
                                            purple_c = true;
                                        }
                                        if (play.card[i] == 5 && play.card[i - 1] != 0 && play.card[i - x] == 0)
                                        {
                                            blue_c = true;
                                        }
                                        x = x - 1;
                                    }
                                    else if (i == 21 || i == 15 || i == 10 || i == 6 || i == 3 || i == 1)
                                    {
                                        if (play.card[i] == 1 && play.card[i + 1] != 0 && play.card[i - x] == 0)
                                        {
                                            green_c = true;
                                        }
                                        if (play.card[i] == 2 && play.card[i + 1] != 0 && play.card[i - x] == 0)
                                        {
                                            yellow_c = true;
                                        }
                                        if (play.card[i] == 3 && play.card[i + 1] != 0 && play.card[i - x] == 0)
                                        {
                                            red_c = true;
                                        }
                                        if (play.card[i] == 4 && play.card[i + 1] != 0 && play.card[i - x] == 0)
                                        {
                                            purple_c = true;

                                        }
                                        if (play.card[i] == 5 && play.card[i + 1] != 0 && play.card[i - x] == 0)
                                        {
                                            blue_c = true;
                                        }
                                    }
                                    else
                                    {
                                        if (play.card[i] == 1 && ((play.card[i + 1] != 0 && play.card[i - x] == 0) || (play.card[i - 1] != 0 && play.card[i - x - 1] == 0)))
                                        {
                                            green_c = true;
                                        }
                                        if (play.card[i] == 2 && ((play.card[i + 1] != 0 && play.card[i - x] == 0) || (play.card[i - 1] != 0 && play.card[i - x - 1] == 0)))
                                        {
                                            yellow_c = true;
                                        }
                                        if (play.card[i] == 3 && ((play.card[i + 1] != 0 && play.card[i - x] == 0) || (play.card[i - 1] != 0 && play.card[i - x - 1] == 0)))
                                        {
                                            red_c = true;
                                        }
                                        if (play.card[i] == 4 && ((play.card[i + 1] != 0 && play.card[i - x] == 0) || (play.card[i - 1] != 0 && play.card[i - x - 1] == 0)))
                                        {
                                            purple_c = true;
                                        }
                                        if (play.card[i] == 5 && ((play.card[i + 1] != 0 && play.card[i - x] == 0) || (play.card[i - 1] != 0 && play.card[i - x - 1] == 0)))
                                        {
                                            blue_c = true;
                                        }
                                    }
                                }
                                if (!ex && !((green_c && P2.green > 0) || (yellow_c && P2.yellow > 0) || (red_c && P2.red > 0) || (purple_c && P2.purple > 0) || (blue_c && P2.blue > 0)))
                                {
                                    Console.WriteLine("もう置けません");
                                    P2.loseturn = turn;
                                    continue;
                                }
                            if (AI == 2)
                            {
                                P2.priority();
                                for (x = 22; x <= 28; x++)
                                {
                                    if (play.card[x - 1] == P2.a_sort[4]) p_c++;
                                }
                                while (randroop)
                                {
                                    area = r.Next(0, 28) + 1;
                                    color = r.Next(1, 6);
                                    /*ランダム用*/
                                    while (turn == 1 && area < 22)
                                    {
                                        area = r.Next(21, 28) + 1;
                                    }
                                    /*エラー対策*/
                                    k++;
                                    if (k == 100000)
                                    {
                                        Console.WriteLine("ERROR");
                                        ec++;
                                        t--;
                                        P2.loseturn = 1;
                                        P1.loseturn = 1;
                                        k = 0;
                                        break;
                                    }
                                    // Console.WriteLine(area + "を選出");
                                    if (play.card[area - 1] == 0)
                                    {
                                        /* 最下段の処理 */
                                        if (area == 22)
                                        {
                                            if (turn == 1)
                                            {
                                                while (roop)
                                                {
                                                    Console.WriteLine("test");
                                                    color = r.Next(1, 6);
                                                    switch (color)
                                                    {
                                                        case 1:
                                                            if (P2.green > 2)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 2:
                                                            if (P2.yellow > 2)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 3:
                                                            if (P2.red > 2)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 4:
                                                            if (P2.purple > 2)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 5:
                                                            if (P2.blue > 2)
                                                            {
                                                                roop = false;
                                                            }

                                                            break;
                                                    }
                                                    play.Deploy(color, area);
                                                }
                                                randroop = false;

                                            }
                                            else if (play.card[area] != 0)
                                            {
                                                if (ex && p_c < 2) color = P2.a_sort[4];
                                                switch (color)
                                                {
                                                    case 1:
                                                        if (P2.green > 0)
                                                        {
                                                            P2.green--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 2:
                                                        if (P2.yellow > 0)
                                                        {
                                                            P2.yellow--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 3:
                                                        if (P2.red > 0)
                                                        {
                                                            P2.red--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 4:
                                                        if (P2.purple > 0)
                                                        {
                                                            P2.purple--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 5:
                                                        if (P2.blue > 0)
                                                        {
                                                            P2.blue--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }

                                                        break;
                                                }
                                            }
                                        }
                                        else if (22 < area && area <= 28)
                                        {
                                            if (turn == 1)
                                            {
                                                while (roop)
                                                {
                                                    color = r.Next(1, 6);
                                                    switch (color)
                                                    {
                                                        case 1:
                                                            if (P2.green > 2)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 2:
                                                            if (P2.yellow > 2)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 3:
                                                            if (P2.red > 2)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 4:
                                                            if (P2.purple > 2)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 5:
                                                            if (P2.blue > 2)
                                                            {
                                                                roop = false;
                                                            }

                                                            break;
                                                    }

                                                }
                                                play.Deploy(color, area);
                                                randroop = false;

                                            }
                                            else if (play.card[area - 2] != 0 || play.card[area] != 0)
                                            {
                                                if (p_c < 2) color = P2.a_sort[4];
                                                switch (color)
                                                {
                                                    case 1:
                                                        if (P2.green > 0)
                                                        {
                                                            P2.green--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 2:
                                                        if (P2.yellow > 0)
                                                        {
                                                            P2.yellow--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 3:
                                                        if (P2.red > 0)
                                                        {
                                                            P2.red--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 4:
                                                        if (P2.purple > 0)
                                                        {
                                                            P2.purple--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 5:
                                                        if (P2.blue > 0)
                                                        {
                                                            P2.blue--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }

                                                        break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (area == 1) stage = 1;
                                            if (2 <= area && area <= 3) stage = 2;
                                            if (4 <= area && area <= 6) stage = 3;
                                            if (7 <= area && area <= 10) stage = 4;
                                            if (11 <= area && area <= 15) stage = 5;
                                            if (16 <= area && area <= 21) stage = 6;
                                            switch (color)
                                            {
                                                case 1:
                                                    if (P2.green > 0 && ((play.card[area + stage - 1] == 1 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 1)))
                                                    {
                                                        P2.green--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 2:
                                                    if (P2.yellow > 0 && ((play.card[area + stage - 1] == 2 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 2)))
                                                    {
                                                        P2.yellow--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 3:
                                                    if (P2.red > 0 && ((play.card[area + stage - 1] == 3 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 3)))
                                                    {
                                                        P2.red--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 4:
                                                    if (P2.purple > 0 && ((play.card[area + stage - 1] == 4 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 4)))
                                                    {
                                                        P2.purple--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 5:
                                                    if (P2.blue > 0 && ((play.card[area + stage - 1] == 5 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 5)))
                                                    {
                                                        P2.blue--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                while (randroop)
                                {
                                    area = r.Next(0, 28) + 1;
                                    /*ランダム用*/
                                    while (turn == 1 && area < 22)
                                    {
                                        area = r.Next(0, 28) + 1;
                                    }

                                    k++;
                                    if (k == 100000)
                                    {
                                        Console.WriteLine("ERROR:1");
                                        ec++;
                                        P2.loseturn = 1;
                                        P1.loseturn = 1;
                                        k = 0;
                                        t--;
                                        break;
                                    }
                                    // Console.WriteLine(area + "を選出");
                                    if (play.card[area - 1] == 0)
                                    {
                                        /* 最下段の処理 */
                                        if (area == 22)
                                        {
                                            if (turn == 1)
                                            {
                                                while (roop)
                                                {
                                                    color = r.Next(1, 6);
                                                    switch (color)
                                                    {
                                                        case 1:
                                                            if (P2.green > 0)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 2:
                                                            if (P2.yellow > 0)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 3:
                                                            if (P2.red > 0)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 4:
                                                            if (P2.purple > 0)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 5:
                                                            if (P2.blue > 0)
                                                            {
                                                                roop = false;
                                                            }

                                                            break;
                                                    }
                                                    play.Deploy(color, area);
                                                }
                                                randroop = false;

                                            }
                                            else if (play.card[area] != 0)
                                            {
                                                color = r.Next(1, 6);

                                                switch (color)
                                                {
                                                    case 1:
                                                        if (P2.green > 0)
                                                        {
                                                            P2.green--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 2:
                                                        if (P2.yellow > 0)
                                                        {
                                                            P2.yellow--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 3:
                                                        if (P2.red > 0)
                                                        {
                                                            P2.red--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 4:
                                                        if (P2.purple > 0)
                                                        {
                                                            P2.purple--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 5:
                                                        if (P2.blue > 0)
                                                        {
                                                            P2.blue--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }

                                                        break;
                                                }
                                            }
                                        }
                                        else if (22 < area && area <= 28)
                                        {
                                            if (turn == 1)
                                            {
                                                while (roop)
                                                {
                                                    color = r.Next(1, 6);
                                                    switch (color)
                                                    {
                                                        case 1:
                                                            if (P2.green > 0)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 2:
                                                            if (P2.yellow > 0)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 3:
                                                            if (P2.red > 0)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 4:
                                                            if (P2.purple > 0)
                                                            {
                                                                roop = false;
                                                            }
                                                            break;
                                                        case 5:
                                                            if (P2.blue > 0)
                                                            {
                                                                roop = false;
                                                            }

                                                            break;
                                                    }

                                                }
                                                play.Deploy(color, area);
                                                randroop = false;

                                            }
                                            else if (play.card[area - 2] != 0 || play.card[area] != 0)
                                            {
                                                color = r.Next(1, 6);
                                                switch (color)
                                                {
                                                    case 1:
                                                        if (P2.green > 0)
                                                        {
                                                            P2.green--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 2:
                                                        if (P2.yellow > 0)
                                                        {
                                                            P2.yellow--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 3:
                                                        if (P2.red > 0)
                                                        {
                                                            P2.red--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 4:
                                                        if (P2.purple > 0)
                                                        {
                                                            P2.purple--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }
                                                        break;
                                                    case 5:
                                                        if (P2.blue > 0)
                                                        {
                                                            P2.blue--;
                                                            play.Deploy(color, area);
                                                            randroop = false;
                                                        }

                                                        break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (area == 1) stage = 1;
                                            if (2 <= area && area <= 3) stage = 2;
                                            if (4 <= area && area <= 6) stage = 3;
                                            if (7 <= area && area <= 10) stage = 4;
                                            if (11 <= area && area <= 15) stage = 5;
                                            if (16 <= area && area <= 21) stage = 6;
                                            color = r.Next(1, 6);
                                            switch (color)
                                            {
                                                case 1:
                                                    if (P2.green > 0 && ((play.card[area + stage - 1] == 1 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 1)))
                                                    {
                                                        P2.green--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 2:
                                                    if (P2.yellow > 0 && ((play.card[area + stage - 1] == 2 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 2)))
                                                    {
                                                        P2.yellow--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 3:
                                                    if (P2.red > 0 && ((play.card[area + stage - 1] == 3 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 3)))
                                                    {
                                                        P2.red--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 4:
                                                    if (P2.purple > 0 && ((play.card[area + stage - 1] == 4 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 4)))
                                                    {
                                                        P2.purple--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                                case 5:
                                                    if (P2.blue > 0 && ((play.card[area + stage - 1] == 5 && play.card[area + stage] != 0) || (play.card[area + stage - 1] != 0 && play.card[area + stage] == 5)))
                                                    {
                                                        P2.blue--;
                                                        play.Deploy(color, area);
                                                        randroop = false;
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        turn++;
                    }
                    k = 0;
                }
                if(P1.loseturn ==1 && P2.loseturn == 1) { continue; }
                if (coin == 1)
                {
                    if (P1.loseturn - P2.loseturn >= 1) { Console.WriteLine("P1の勝ち"); P1.point += (float)P1.Hand(0); P1.Maxcount(); P1.winc++;
                        aturn += P2.loseturn;
                    }
                    else if (P2.loseturn - P1.loseturn + coin - 1 > 1) { Console.WriteLine("P2の勝ち"); P2.point += (float)P2.Hand(0); P2.Maxcount(); P2.winc++;
                        bturn += P1.loseturn;
                    }
                    else { draw++;
                        drawscore += P1.Hand(0);
                    }
                }
                else if (coin == 2)
                {
                    if (P1.loseturn - P2.loseturn > 1) { Console.WriteLine("P1の勝ち"); P1.point += (float)P1.Hand(0); P1.Maxcount(); P1.winc++;
                        aturn += P2.loseturn;
                    }
                    else if (P2.loseturn - P1.loseturn >= 1) { Console.WriteLine("P2の勝ち"); P2.point += (float)P2.Hand(0); P2.Maxcount(); P2.winc++;
                        bturn += P1.loseturn;
                    }
                    else { draw++; }
                }
                    
                
            }
            Console.WriteLine(" ");
            Console.WriteLine("P1 勝利数:"+P1.winc+"平均点:"+P1.point/(float)P1.winc+"最高点:"+P1.Max + "平均決着ターン" + aturn / P1.winc); 
            Console.WriteLine("P2 勝利数:"+P2.winc+"平均点:"+P2.point/(float)P2.winc+"最高点:"+P2.Max + "平均決着ターン" + bturn / P2.winc);
            Console.WriteLine("総合平均決着ターン:" + (aturn+bturn)/(P1.winc+P2.winc));
            Console.WriteLine("引き分け数:" + draw);
            Console.WriteLine("エラー数:"+ec);
            Console.WriteLine("試合数:" + t);
            Console.WriteLine("キー入力して終了");
            Console.ReadKey();
        }
 
    }
}
