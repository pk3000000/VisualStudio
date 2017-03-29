using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    enum AtkType { MELEE, RANGE}; // 공격 타입
    enum Special { NEWTYPE }; // 캐릭터 특수능력
    enum MoveType { SEA=1,LAND=2,COSMOS=4}; // 환경 타입
    enum RobotSize { S,M,L };       // 로봇 크기
    enum Terrain {S,A,B,C,D};                // 지형
    class Weapon        // 무기
    {
        string name;    // 기술 이름
        int demage;     // 공격력
        int maxRange;   // 최대 사거리
        int accuracy;   // 명중력
        AtkType atkType;// 공격 타입
        int bullet;     // 탄환 수
        int power;      // 필요 기력
        int en;         // 사용 EN
        int critical;   // 크리티컬 보정
    }

    class Robot         // 로봇
    {
        Weapon[] weapons;

        string name;        // 기체 이름
        int hp;             // HP
        int en;             // EN
        int physical;       // 운동성 - 회피력에 영향
        int move;           // 최대 이동 범위
        int guard;          // 장갑치 - 방어력에 영향
        byte moveType;  // 환경 타입
        RobotSize robotSize; // 로봇 크기
    }

    class Spacial           // 특수기능
    {
        string name;        // 이름
        int level;          // 레벨

        public void func()  // 특수 기능 효과
        {

        }
    }

    class Mental            // 정신 커맨드
    {
        string name;        // 이름
        int sp;             // 소비 정신
        public void func()  // 정신 기능
        {

        }
    }

    class Character         // 인물
    {
        string name;        // 이름
        int level;          // 레벨
        int exp;            // 경험치
        int dst;            // 격추수
        int sp;             // 정신
        int melee;          // 격투
        int shoot;          // 사격
        int wms;            // 기량(Workmanship)
        int evation;        // 회피
        int accuracy;       // 회피
        Terrain sky;        // 공중
        Terrain land;       // 땅
        Terrain sea;        // 바다
        Terrain cosmos;     // 우주
        Special[] special;  // 특수 기능
        Mental[] mental;    // 정신 커맨드
    }

    class unit
    {
        Robot robot;
        Character character;

        public void move()
        {

        }
        public void func()  // 공격,수리,정신커맨드 사용 등
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
