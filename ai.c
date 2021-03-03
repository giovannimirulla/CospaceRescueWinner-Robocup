//CsBot_AI_H
//Do NOT delete the Above Line
///////////////////////////////

//The robot ID : It must be two char, such as '00','kl' or 'Cr'.
char AI_MyID[2] = {'0','2'};
///////////////////////////////////
int AI_MotorType = 0;
int Duration = 0;
int SuperDuration = 0;
int bGameEnd = false;
int CurAction = -1;
int CurGame = 0;
int SuperObj_Num = 0;
int SuperObj_X = 0;
int SuperObj_Y = 0;
int Teleport = 0;
int LoadedObjects = 0;
int US_Front = 0;
int US_Left = 0;
int US_Right = 0;
int CSLeft_R = 0;
int CSLeft_G = 0;
int CSLeft_B = 0;
int CSRight_R = 0;
int CSRight_G = 0;
int CSRight_B = 0;
int PositionX = 0;
int PositionY = 0;
int TM_State = 0;
int Compass = 0;
int Time = 0;
int WheelLeft = 0;
int WheelRight = 0;
int LED_1 = 0;
int MyState = 0;
int AI_SensorNum = 13;



//CsBot_AI_C
//Do NOT delete the Above Line
///////////////////////////////

 
//Only Used by CsBot Dance Platform
void SetGameID(int GameID)
{
    CurGame = GameID;
    bGameEnd = false;
}

 
//Only Used by CsBot Dance Platform
int GetGameID()
{
    return CurGame;
}

 
//Only Used by CsBot Dance Platform
int IsGameEnd()
{
    return bGameEnd;
}

 
//Only Used by CsBot Rescue Platform
int GetTeleport()
{
    return Teleport;
}

 
//Only Used by CsBot Rescue Platform
void SetSuperObj(int X, int Y, int num)
{
    SuperObj_X = X;
    SuperObj_Y = Y;
    SuperObj_Num = num;
}
void SetDataAI(volatile int *AI_CCP , volatile int *AI_ADC ,volatile int *AI_INFO)
{

    int sum = 0;

    US_Front = AI_ADC[0]; packet[0] = US_Front; sum += US_Front;
    US_Left = AI_ADC[2]; packet[1] = US_Left; sum += US_Left;
    US_Right = AI_ADC[3]; packet[2] = US_Right; sum += US_Right;
    CSLeft_R = AI_CCP[1]; packet[3] = CSLeft_R; sum += CSLeft_R;
    CSLeft_G = AI_CCP[2]; packet[4] = CSLeft_G; sum += CSLeft_G;
    CSLeft_B = AI_CCP[3]; packet[5] = CSLeft_B; sum += CSLeft_B;
    CSRight_R = AI_CCP[4]; packet[6] = CSRight_R; sum += CSRight_R;
    CSRight_G = AI_CCP[5]; packet[7] = CSRight_G; sum += CSRight_G;
    CSRight_B = AI_CCP[6]; packet[8] = CSRight_B; sum += CSRight_B;
    PositionX = AI_INFO[2]; packet[9] = PositionX; sum += PositionX;
    PositionY = AI_INFO[3]; packet[10] = PositionY; sum += PositionY;
    TM_State = AI_INFO[1]; packet[11] = TM_State; sum += TM_State;
    Compass = AI_Compass; packet[12] = Compass; sum += Compass;
    Time = Play_Time_MS/1000;
    packet[13] = sum;

}
void GetCommand(int *Motor, int *LegoMotor, int *LED , int *Info)
{
    Motor[0] = WheelLeft;
    Motor[2] = WheelRight;
    LED[0] = LED_1;
    Info[0] = MyState;
}
void Game0()
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
            if(Duration < 6)
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
            if(Duration < 6)
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
            if(Duration < 6)
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
            if(Duration < 6)
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
            if(Duration < 6)
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
            if(Duration < 6)
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
            if(Duration == 1) {LoadedObjects = 0; } 
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

void Game1()
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
            if(Duration == 1) {LoadedObjects = 0; } 
            break;
        case 7:
            WheelLeft=0;
            WheelRight=0;
            LED_1=1;
            MyState=0;
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
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
            if(Duration < 6)
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
            if(Duration < 6)
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
            if(Duration < 6)
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
            if(Duration < 6)
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
            if(Duration < 6)
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


void OnTimer()
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
