using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        // 실습 1 + 메모리 배리어 추가
        /*static int x = 0;
        static int y = 0;
        static int r1 = 0;
        static int r2 = 0;

        static void Thread_1()
        {
            y = 1;

            Thread.MemoryBarrier();

            r1 = x;
        }

        static void Thread_2()
        {
            x = 1;

            Thread.MemoryBarrier()

            r2 = y;
        }

        static void Main(string[] args)
        {
            int count = 0;
            while(true)
            {
                count++;
                x = y = 0;

                Task t1 = new Task(Thread_1);
                Task t2 = new Task(Thread_2);
                t1.Start();
                t2.Start();

                Task.WaitAll(t1, t2);

                if (r1 == 0 && r2 == 0)
                    break;
            }

            Console.WriteLine($"{count}번만에 빠져나옴!");
        }*/

        // 실습 2
        int _answer;
        bool _complete;

        void A()
        {
            _answer = 123;
            Thread.MemoryBarrier();
            _complete = true;
            Thread.MemoryBarrier();
        }

        void B()
        {
            Thread.MemoryBarrier();
            if (_complete )
            {
                Thread.MemoryBarrier();
                Console.WriteLine(_answer);
            }
        }

        static void Main(string[] args)
        {

        }
    }
}