using System;

namespace AI
{
    public static class AI
    {
        static int Duration = 0;
        static int SuperDuration = 0;
        static bool bGameEnd = false;
        static int CurAction = -1;
        static int CurGame = 0;
        static int SuperObj_Num = 0;
        static int SuperObj_X = 0;
        static int SuperObj_Y = 0;
        static int Teleport = 0;
        static int LoadedObjects = 0;
        static int US_Front = 0;
        static int US_Left = 0;
        static int US_Right = 0;
        static int CSLeft_R = 0;
        static int CSLeft_G = 0;
        static int CSLeft_B = 0;
        static int CSRight_R = 0;
        static int CSRight_G = 0;
        static int CSRight_B = 0;
        static int PositionX = 0;
        static int PositionY = 0;
        static int TM_State = 0;
        static int Compass = 0;
        static int Time = 0;
        static int WheelLeft = 0;
        static int WheelRight = 0;
        static int LED_1 = 0;
        static int MyState = 0;

        public static string GetDebugInfo()
        {
            return "Duration="+Duration+";"+"SuperDuration="+SuperDuration+";"+"bGameEnd="+bGameEnd+";"+"CurAction="+CurAction+";"+"CurGame="+CurGame+";"+"SuperObj_Num="+SuperObj_Num+";"+"SuperObj_X="+SuperObj_X+";"+"SuperObj_Y="+SuperObj_Y+";"+"Teleport="+Teleport+";"+"LoadedObjects="+LoadedObjects+";"+"US_Front="+US_Front+";"+"US_Left="+US_Left+";"+"US_Right="+US_Right+";"+"CSLeft_R="+CSLeft_R+";"+"CSLeft_G="+CSLeft_G+";"+"CSLeft_B="+CSLeft_B+";"+"CSRight_R="+CSRight_R+";"+"CSRight_G="+CSRight_G+";"+"CSRight_B="+CSRight_B+";"+"PositionX="+PositionX+";"+"PositionY="+PositionY+";"+"TM_State="+TM_State+";"+"Compass="+Compass+";"+"Time="+Time+";"+"WheelLeft="+WheelLeft+";"+"WheelRight="+WheelRight+";"+"LED_1="+LED_1+";"+"MyState="+MyState+";"+"";
        }
 
        public static int GetCurAction()
        {
            return CurAction;
        }

 
        public static string GetTeamName()
        {
             return "Papaoutai";
        }

 
        public static string GetGameName(int GameID)
        {
            if (GameID < 0 || GameID > 8) return string.Empty;
            if (GameID == 0) return  "Game0";
            else if (GameID == 1) return "Game1";
            else if (GameID == 2) return "Game2";
            else if (GameID == 3) return "Game3";
            else if (GameID == 4) return "Game4";
            else if (GameID == 5) return "Game5";
            else if (GameID == 6) return "Game6";
            else if (GameID == 7) return "Game7";
            else if (GameID == 8) return "Game8";
            else if (GameID == 9) return "Wait";
            else if (GameID == 10) return "Stop";
            return string.Empty;
        }
 
 
        public static void SetGameID(int GameID)
        {
            CurGame = GameID;
            bGameEnd = false;
        }

 
        public static int GetGameID()
        {
            return CurGame;
        }

 
        public static int GetTeleport()
        {
            return Teleport;
        }

 
        public static void GetSuperObj(ref int x, ref int y, ref int num)
        {
            x = SuperObj_X;
            y = SuperObj_Y;
            num = SuperObj_Num;
        }
 
        public static void SetSuperObj(int X, int Y, int num)
        {
            SuperObj_X = X;
            SuperObj_Y = Y;
            SuperObj_Num = num;
        }
 
        public static bool IsGameEnd()
        {
            return bGameEnd;
        }

        public static void OnTimer()
        {
            switch (CurGame)
            {
                case 9:
                    break;
                case 10:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=0;
                    MyState=0;
                    break;
                case 0:
                    Game0();
                    break;
                case 1:
                    Game1();
                    break;
                default:
                    break;
            }
        }
        public static void SetData(int Sensor0 , int Sensor1 , int Sensor2 , int Sensor3 , int Sensor4 , int Sensor5 , int Sensor6 , int Sensor7 , int Sensor8 , int Sensor9 , int Sensor10 , int Sensor11 , int Sensor12 , int Sensor13)
        {
            US_Front = Sensor0;
            US_Left = Sensor1;
            US_Right = Sensor2;
            CSLeft_R = Sensor3;
            CSLeft_G = Sensor4;
            CSLeft_B = Sensor5;
            CSRight_R = Sensor6;
            CSRight_G = Sensor7;
            CSRight_B = Sensor8;
            PositionX = Sensor9;
            PositionY = Sensor10;
            TM_State = Sensor11;
            Compass = Sensor12;
            Time = Sensor13;
        }
        public static void GetCommand(ref int Actuator0 , ref int Actuator1 , ref int Actuator2 , ref int Actuator3)
        {
            Actuator0 = WheelLeft;
            Actuator1 = WheelRight;
            Actuator2 = LED_1;
            Actuator3 = MyState;
        }
        private static void Game0()
        {

            if(SuperDuration>0)
            {
                SuperDuration--;
            }
            else if(Duration>0)
            {
                Duration--;
            }
            else if(CSRight_R>=200 && CSRight_R<=255 && CSRight_G>=200 && CSRight_G<=255 && CSRight_B>=40 && CSRight_B<=60)
            {
                Duration = 9;
                CurAction =1;
            }
            else if(CSLeft_R>=200 && CSLeft_R<=255 && CSLeft_G>=200 && CSLeft_G<=255 && CSLeft_B>=40 && CSLeft_B<=60)
            {
                Duration = 9;
                CurAction =2;
            }
            else if(CSLeft_R>=40 && CSLeft_R<=50 && CSLeft_G>=40 && CSLeft_G<=50 && CSLeft_B>=225 && CSLeft_B<=255)
            {
                Duration = 9;
                CurAction =3;
            }
            else if(CSRight_R>=40 && CSRight_R<=50 && CSRight_G>=40 && CSRight_G<=50 && CSRight_B>=225 && CSRight_B<=255)
            {
                Duration = 9;
                CurAction =4;
            }
            else if(US_Front>=0 && US_Front<=15)
            {
                Duration = 1;
                CurAction =5;
            }
            else if(CSLeft_R>=100 && CSLeft_R<=255 && CSLeft_G>=0 && CSLeft_G<=50 && CSLeft_B>=0 && CSLeft_B<=50)
            {
                Duration = 49;
                CurAction =6;
            }
            else if(CSRight_R>=100 && CSRight_R<=255 && CSRight_G>=0 && CSRight_G<=50 && CSRight_B>=0 && CSRight_B<=50)
            {
                Duration = 49;
                CurAction =7;
            }
            else if(CSLeft_R>=30 && CSLeft_R<=50 && CSLeft_G>=100 && CSLeft_G<=255 && CSLeft_B>=30 && CSLeft_B<=50)
            {
                Duration = 49;
                CurAction =8;
            }
            else if(CSRight_R>=30 && CSRight_R<=50 && CSRight_G>=100 && CSRight_G<=255 && CSRight_B>=30 && CSRight_B<=50)
            {
                Duration = 49;
                CurAction =9;
            }
            else if(CSLeft_R>=0 && CSLeft_R<=40 && CSLeft_G>=0 && CSLeft_G<=40 && CSLeft_B>=0 && CSLeft_B<=40)
            {
                Duration = 49;
                CurAction =10;
            }
            else if(CSRight_R>=0 && CSRight_R<=40 && CSRight_G>=0 && CSRight_G<=40 && CSRight_B>=0 && CSRight_B<=40)
            {
                Duration = 49;
                CurAction =11;
            }
            else if(CSLeft_R>=200 && CSLeft_R<=255 && CSLeft_G>=80 && CSLeft_G<=100 && CSLeft_B>=0 && CSLeft_B<=10 && CSRight_R>=200 && CSRight_R<=255 && CSRight_G>=80 && CSRight_G<=100 && CSRight_B>=0 && CSRight_B<=10)
            {
                Duration = 49;
                CurAction =12;
            }
            else if(true)
            {
                Duration = 0;
                CurAction =13;
            }
            switch(CurAction)
            {
                case 1:
                    WheelLeft=-4;
                    WheelRight=-2;
                    LED_1=0;
                    MyState=0;
                    break;
                case 2:
                    WheelLeft=-2;
                    WheelRight=-4;
                    LED_1=0;
                    MyState=0;
                    break;
                case 3:
                    WheelLeft=-2;
                    WheelRight=-4;
                    LED_1=0;
                    MyState=0;
                    break;
                case 4:
                    WheelLeft=-4;
                    WheelRight=-2;
                    LED_1=0;
                    MyState=0;
                    break;
                case 5:
                    WheelLeft=3;
                    WheelRight=-3;
                    LED_1=0;
                    MyState=0;
                    break;
                case 6:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        WheelLeft = 2;
                        WheelRight = 2;
                    }
                    break;
                case 7:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        WheelLeft = 2;
                        WheelRight = 2;
                    }
                    break;
                case 8:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        WheelLeft = 2;
                        WheelRight = 2;
                    }
                    break;
                case 9:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        WheelLeft = 2;
                        WheelRight = 2;
                    }
                    break;
                case 10:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        WheelLeft = 2;
                        WheelRight = 2;
                    }
                    break;
                case 11:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        WheelLeft = 2;
                        WheelRight = 2;
                    }
                    break;
                case 12:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=2;
                    MyState=0;
                    if(Duration == 1) {  LoadedObjects = 0;}
                    break;
                case 13:
                    WheelLeft=3;
                    WheelRight=3;
                    LED_1=0;
                    MyState=0;
                    break;
                default:
                    break;
            }

        }

        private static void Game1()
        {

            if(SuperDuration>0)
            {
                SuperDuration--;
            }
            else if(Duration>0)
            {
                Duration--;
            }
            else if(CSLeft_R>=100 && CSLeft_R<=110 && CSLeft_G>=100 && CSLeft_G<=120 && CSLeft_B>=160 && CSLeft_B<=180 && CSRight_B>=1 && CSRight_B<=255)
            {
                Duration = 1;
                CurAction =1;
            }
            else if(CSRight_R>=100 && CSRight_R<=110 && CSRight_G>=100 && CSRight_G<=120 && CSRight_B>=160 && CSRight_B<=180)
            {
                Duration = 1;
                CurAction =2;
            }
            else if(US_Front>=0 && US_Front<=15)
            {
                Duration = 1;
                CurAction =3;
            }
            else if(CSLeft_R>=100 && CSLeft_R<=120 && CSLeft_G>=115 && CSLeft_G<=135 && CSLeft_B>=0 && CSLeft_B<=20)
            {
                Duration = 1;
                CurAction =4;
            }
            else if(CSLeft_R>=100 && CSLeft_R<=120 && CSLeft_G>=115 && CSLeft_G<=135 && CSLeft_B>=0 && CSLeft_B<=20)
            {
                Duration = 1;
                CurAction =5;
            }
            else if(CSLeft_R>=200 && CSLeft_R<=255 && CSLeft_G>=80 && CSLeft_G<=100 && CSLeft_B>=0 && CSLeft_B<=10 && CSRight_R>=200 && CSRight_R<=255 && CSRight_G>=80 && CSRight_G<=100 && CSRight_B>=0 && CSRight_B<=10)
            {
                Duration = 49;
                CurAction =6;
            }
            else if(CSLeft_R>=100 && CSLeft_R<=255 && CSLeft_G>=0 && CSLeft_G<=50 && CSLeft_B>=0 && CSLeft_B<=50)
            {
                Duration = 49;
                CurAction =7;
            }
            else if(CSRight_R>=100 && CSRight_R<=255 && CSRight_G>=0 && CSRight_G<=50 && CSRight_B>=0 && CSRight_B<=50)
            {
                Duration = 49;
                CurAction =8;
            }
            else if(CSLeft_R>=30 && CSLeft_R<=50 && CSLeft_G>=100 && CSLeft_G<=255 && CSLeft_B>=30 && CSLeft_B<=50)
            {
                Duration = 49;
                CurAction =9;
            }
            else if(CSRight_R>=30 && CSRight_R<=50 && CSRight_G>=100 && CSRight_G<=255 && CSRight_B>=30 && CSRight_B<=50)
            {
                Duration = 49;
                CurAction =10;
            }
            else if(CSLeft_R>=0 && CSLeft_R<=40 && CSLeft_G>=0 && CSLeft_G<=40 && CSLeft_B>=0 && CSLeft_B<=40)
            {
                Duration = 49;
                CurAction =11;
            }
            else if(CSRight_R>=0 && CSRight_R<=40 && CSRight_G>=0 && CSRight_G<=40 && CSRight_B>=0 && CSRight_B<=40)
            {
                Duration = 49;
                CurAction =12;
            }
            else if(true)
            {
                Duration = 0;
                CurAction =13;
            }
            switch(CurAction)
            {
                case 1:
                    WheelLeft=2;
                    WheelRight=-2;
                    LED_1=0;
                    MyState=0;
                    break;
                case 2:
                    WheelLeft=-2;
                    WheelRight=2;
                    LED_1=0;
                    MyState=0;
                    break;
                case 3:
                    WheelLeft=3;
                    WheelRight=-3;
                    LED_1=0;
                    MyState=0;
                    break;
                case 4:
                    WheelLeft=2;
                    WheelRight=-2;
                    LED_1=0;
                    MyState=0;
                    break;
                case 5:
                    WheelLeft=-2;
                    WheelRight=2;
                    LED_1=0;
                    MyState=0;
                    break;
                case 6:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=2;
                    MyState=0;
                    if(Duration == 1) {  LoadedObjects = 0;}
                    break;
                case 7:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        WheelLeft = 2;
                        WheelRight = 2;
                    }
                    break;
                case 8:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        WheelLeft = 2;
                        WheelRight = 2;
                    }
                    break;
                case 9:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        WheelLeft = 2;
                        WheelRight = 2;
                    }
                    break;
                case 10:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        WheelLeft = 2;
                        WheelRight = 2;
                    }
                    break;
                case 11:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        WheelLeft = 2;
                        WheelRight = 2;
                    }
                    break;
                case 12:
                    WheelLeft=0;
                    WheelRight=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        WheelLeft = 2;
                        WheelRight = 2;
                    }
                    break;
                case 13:
                    WheelLeft=2;
                    WheelRight=2;
                    LED_1=0;
                    MyState=0;
                    break;
                default:
                    break;
            }

        }


    }
}
