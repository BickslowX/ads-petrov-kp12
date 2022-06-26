using System;
using System.Collections.Generic;

namespace ads_lab7
{
    internal class Program
    {
        static void Main()
        {
            Hashtable<Passanger> passHashTable = new Hashtable<Passanger>(19);
            Hashtable<List<string>> flHashtable = new Hashtable<List<string>>(19);
            while (true)
            {
                Console.WriteLine("Виберiть операцiю:\n" +
                    "1. Додати пасажира\n" +
                    "2. Видалити пасажира\n" +
                    "3. Вiдобразити iнформацiю о пасажирах\n" +
                    "4. Вiдобразити iнформацiю про рейс\n" +
                    "5. Вiдобразити iнформацiю про всiх пасажирiв\n" +
                    "6. Вихiд");
                Console.Write("\nНомер операцii: ");
                byte choosenOperation = Convert.ToByte(Console.ReadLine());
                switch (choosenOperation)
                {
                    case 1:
                        AddPass(passHashTable, flHashtable);
                        break;
                    case 2:
                        DelPass(passHashTable, flHashtable);
                        break;
                    case 3:
                        DispPassInf(passHashTable);
                        break;
                    case 4:
                        DispFlPassInf(passHashTable, flHashtable);
                        break;
                    case 5:
                        DispAllPassInf(passHashTable);
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Невiрний номер операцii");
                        break;
                }
            }
        }

        private static string GenResNum()
        {
            Random random = new Random();
            string reservationNumber = "";

            for (int i = 0; i < 7; i++)
            {
                if (i < 2 || i == 5)
                {
                    reservationNumber += Convert.ToChar(random.Next(65, 91));
                }
                else
                {
                    reservationNumber += Convert.ToChar(random.Next(48, 58));
                }
            }
            return reservationNumber;
        }
        private static void AddPass(Hashtable<Passanger> passHashTable, Hashtable<List<string>> flHashtable)
        {
            Console.Write("\nПрiзвище: ");
            string lastName = Console.ReadLine();
            Console.Write("Passport ID: ");
            string passportID = Console.ReadLine();
            Console.Write("Код рейсу: ");
            string flightCode = Console.ReadLine();
            Console.Write("Мiсце: ");
            string seat = Console.ReadLine();
            bool priorityBoarding;
            while (true)
            {
                Console.Write("Прiорiтетна посадка (true or false): ");
                string priorityBoardingStr = Console.ReadLine();
                if (priorityBoardingStr == "true" || priorityBoardingStr == "false")
                {
                    priorityBoarding = Convert.ToBoolean(priorityBoardingStr);
                    break;
                }
                Console.WriteLine("Введiть true або false");
            }


            string reservationNumber = GenResNum();

            Console.WriteLine($"Номер бронювання: {reservationNumber}");

            Passanger passanger = new Passanger(lastName, passportID, flightCode, seat, priorityBoarding);

            if (flHashtable.Contains(flightCode))
            {
                List<string> flightPassangers = flHashtable.GetValue(flightCode);
                for (int i = 0; i < flightPassangers.Count; i++)
                {
                    string passangerSeat = passHashTable.GetValue(flightPassangers[i]).Seat;
                    string passangerLastName = passHashTable.GetValue(flightPassangers[i]).LastName;
                    string passangerPassportID = passHashTable.GetValue(flightPassangers[i]).PassportID;

                    if (passangerPassportID == passportID || passangerLastName == lastName || passangerSeat == seat)
                    {
                        Console.WriteLine("Пасажири не можуть мати однаковi паспортнi документи, мiсце або прiзвище");
                        return;
                    }
                }
                flHashtable.GetValue(flightCode).Add(reservationNumber);
            }
            else
            {
                List<string> passangers = new List<string>();
                passangers.Add(reservationNumber);
                flHashtable.Add(flightCode, passangers);
            }
            passHashTable.Add(reservationNumber, passanger);
            Console.WriteLine();
        }

        private static void DelPass(Hashtable<Passanger> passHashTable, Hashtable<List<string>> flHashtable)
        {
            Console.Write("\nНомер бронювання: ");
            string reservationNumber = Console.ReadLine();
            if (passHashTable.Contains(reservationNumber))
            {
                string flightCode = passHashTable.GetValue(reservationNumber).FlightCode;
                flHashtable.GetValue(flightCode).Remove(reservationNumber);
                passHashTable.Delete(reservationNumber);
            }
            else
            {
                Console.WriteLine("Хеш-таблиця не мiстить iнформацiї про цього пасажира");
            }
            Console.WriteLine();
        }
        private static void DispPassInf(Hashtable<Passanger> passHashTable)
        {
            Console.Write("\nНомер бронювання: ");
            string reservationNumber = Console.ReadLine();
            if (passHashTable.Contains(reservationNumber) == false)
            {
                Console.WriteLine("Цього пасажира не iснує");
                return;
            }
            Passanger passanger = passHashTable.GetValue(reservationNumber);
            Console.WriteLine($"Прiзвище: {passanger.LastName}, Passport ID: {passanger.PassportID}, " +
                $"Мiсце: {passanger.Seat}, Прiоритетна посадка: {passanger.PriorityBoarding}.");
            Console.WriteLine();
        }
        private static void DispFlPassInf(Hashtable<Passanger> passHashTable, Hashtable<List<string>> flHashtable)
        {
            Console.Write("\nКод рейсу: ");
            string flightCode = Console.ReadLine();
            if (flHashtable.Contains(flightCode))
            {
                List<string> flightPassangers = flHashtable.GetValue(flightCode);
                for (int i = 0; i < flightPassangers.Count; i++)
                {
                    Passanger passanger = passHashTable.GetValue(flightPassangers[i]);
                    Console.WriteLine($"{i + 1}. Номер бронювання: {flightPassangers[i]}, Прiзвище: {passanger.LastName}, Passport ID: {passanger.PassportID}, " +
                        $"Мiсце: {passanger.Seat}, Прiоритетна посадка: {passanger.PriorityBoarding}.");
                }
            }
            else
            {
                Console.WriteLine("Цей рейс не iснує");
            }
            Console.WriteLine();
        }
        private static void DispAllPassInf(Hashtable<Passanger> passHashTable)
        {
            Console.WriteLine("\nУсi пасажири:");
            int numberOfPassanger = 1;
            foreach (string key in passHashTable)
            {
                if (key != null && passHashTable.Contains(key))
                {
                    Passanger passanger = passHashTable.GetValue(key);
                    Console.WriteLine($"{numberOfPassanger}. Прiзвище: {passanger.LastName}, Passport ID: {passanger.PassportID}, " +
                    $"Мiсце: {passanger.Seat}, Прiоритетна посадка: {passanger.PriorityBoarding}, Номер бронювання: {key}.");
                    numberOfPassanger++;
                }
            }
            Console.WriteLine();
        }
        struct Passanger
        {
            private string _lastName;
            private string _passportID;
            private string _flightCode;
            private string _seat;
            private bool _priorityBoarding;

            public Passanger(string _lastName, string _passportID, string _flightCode, string _seat, bool _priorityBoarding)
            {
                this._lastName = _lastName;
                this._passportID = _passportID;
                this._flightCode = _flightCode;
                this._seat = _seat;
                this._priorityBoarding = _priorityBoarding;
            }
            public string LastName { get { return _lastName; } }
            public string PassportID { get { return _passportID; } }
            public string FlightCode { get { return _flightCode; } }
            public string Seat { get { return _seat; } }
            public bool PriorityBoarding { get { return _priorityBoarding; } }
        }
        class Hashtable<T>
        {
            private Node[] table;

            private int count = 0;

            public Hashtable(int size)
            {
                table = new Node[size];
            }

            public int Count { get { return count; } }

            public void Add(string key, T value)
            {
                if (count == (int)(0.75 * table.Length))
                {
                    RehashTable();
                }

                Node item = new Node(key, value);
                var position = GetHash(key);


                while (table[position] != null && table[position].IsDeleted == false)
                {
                    position = (position + GetSecondHash(position)) % table.Length;
                }


                table[position] = item;
                count++;
            }

            public void Delete(string key)
            {
                var position = GetHash(key);

                while (table[position].Key != key)
                {
                    position = (position + GetSecondHash(position)) % table.Length;
                }

                table[position].IsDeleted = true;
            }

            public T GetValue(string key)
            {
                var position = GetHash(key);

                while (table[position].Key != key || table[position].IsDeleted)
                {
                    position = (position + GetSecondHash(position)) % table.Length;
                }

                return table[position].Data;
            }

            private void RehashTable()
            {
                int newTableSize = GetNewSize();

                Node[] tempTable = new Node[table.Length];

                table.CopyTo(tempTable, 0);
                table = new Node[newTableSize];

                for (int i = 0; i < tempTable.Length; i++)
                {
                    if (tempTable[i] != null)
                    {
                        Add(tempTable[i].Key, tempTable[i].Data);
                    }

                }
            }

            public bool Contains(string key)
            {
                var position = GetHash(key);
                if (table[position] != null)
                {
                    while (!table[position].IsDeleted && table[position].Key != key)
                    {
                        position = (position + GetSecondHash(position)) % table.Length;
                        if (table[position] == null)
                        {
                            break;
                        }
                    }
                }

                return table[position] != null;
            }

            private int GetHash(string key)
            {
                int hash = 0;
                for (int i = 0; i < key.Length; i++)
                {
                    hash += Convert.ToInt32(key[i]);
                }
                return hash % table.Length;
            }

            private int GetNewSize()
            {
                int newSize = table.Length * 2;
                while (PrimeNumChecker(newSize) == false)
                {
                    newSize++;
                }
                return newSize;
            }

            private int GetSecondHash(int position)
            {
                return (table.Length - 1) - (position % (table.Length - 1));
            }

            private static int FastPow(int number, int power, int modulus)
            {
                long res = 1;
                number = number % modulus;
                while (power != 0)
                {
                    if (power % 2 == 1)
                    {
                        res = (res * number) % modulus;
                    }
                    power = power / 2;
                    number = (number * number) % modulus;
                }
                return (int)res;
            }

            private static bool PrimeNumChecker(int num)
            {
                if (FastPow(2, num - 1, num) == 1)
                {
                    return true;
                }
                return false;
            }

            public HashtableEnumerator GetEnumerator()
            {
                return new HashtableEnumerator(this);
            }

            public class HashtableEnumerator
            {
                int nIndex;
                Hashtable<T> collection;
                public HashtableEnumerator(Hashtable<T> coll)
                {
                    collection = coll;
                    nIndex = -1;
                }

                public bool MoveNext()
                {
                    nIndex++;
                    return (nIndex < collection.table.Length);
                }
                public string Current => collection.table[nIndex] != null ? collection.table[nIndex].Key : null;
            }

            public class Node
            {
                public Node(string key, T data)
                {
                    Data = data;
                    Key = key;
                    IsDeleted = false;
                }
                public bool IsDeleted { get; set; }
                public string Key { get; set; }
                public T Data { get; set; }
            }
        }
    }
}
