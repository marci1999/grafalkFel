using System;
using System.Collections.Generic;

namespace GrafFeladat_CSharp
{
    /// <summary>
    /// Irányítatlan, egyszeres gráf.
    /// </summary>
    class Graf
    {
        int csucsokSzama;
        /// <summary>
        /// A gráf élei.
        /// Ha a lista tartalmaz egy(A, B) élt, akkor tartalmaznia kell
        /// a(B, A) vissza irányú élt is.
        /// </summary>
        readonly List<El> elek = new List<El>();
        /// <summary>
        /// A gráf csúcsai.
        /// A gráf létrehozása után új csúcsot nem lehet felvenni.
        /// </summary>
        readonly List<Csucs> csucsok = new List<Csucs>();

        /// <summary>
        /// Létehoz egy úgy, N pontú gráfot, élek nélkül.
        /// </summary>
        /// <param name="csucsok">A gráf csúcsainak száma</param>
        public Graf(int csucsok)
        {
            this.csucsokSzama = csucsok;

            // Minden csúcsnak hozzunk létre egy új objektumot
            for (int i = 0; i < csucsok; i++)
            {
                this.csucsok.Add(new Csucs(i));
            }
        }

        /// <summary>
        /// Hozzáad egy új élt a gráfhoz.
        /// Mindkét csúcsnak érvényesnek kell lennie:
        /// 0 &lt;= cs &lt; csúcsok száma.
        /// </summary>
        /// <param name="cs1">Az él egyik pontja</param>
        /// <param name="cs2">Az él másik pontja</param>
        public void Hozzaad(int cs1, int cs2)
        {
            if (cs1 < 0 || cs1 >= csucsokSzama ||
                cs2 < 0 || cs2 >= csucsokSzama)
            {
                throw new ArgumentOutOfRangeException("Hibas csucs index");
            }

            // Ha már szerepel az él, akkor nem kell felvenni
            foreach (var el in elek)
            {
                if (el.Csucs1 == cs1 && el.Csucs2 == cs2)
                {
                    return;
                }
            }

            elek.Add(new El(cs1, cs2));
            elek.Add(new El(cs2, cs1));
        }

        public void torol(int csucs){
            List<Csucs> csucsId = new List<Csucs>(); 
            Console.WriteLine("kisérlet a "+csucs+" csucs törlésére");
            foreach (var item in csucsok)
	        {
                if (item.getId() == csucs)
                {
                    csucsId.Add(item);
                    List<El> id = new List<El>(); 
                    foreach (var item2 in elek)
                    {
                        if (item2.Csucs1 == csucs || item2.Csucs2 == csucs)
                        {
                            id.Add(item2);
                        }
                    }
                    foreach (var item2 in id)
                    {
                        //El adotEl = elek.IndexOf(item2);
                        elek.Remove(item2);
                    }
                }
            }
            foreach (var item in csucsId)
            {
                csucsok.Remove(item);
            }
	    }

        public HashSet<int> selsegBejaras(int kezd){
            HashSet<int> csucssorrend= new HashSet<int>();

            Queue<int> elem = new Queue<int>();
            elem.Enqueue(kezd);
            csucssorrend.Add(kezd);

            do
	        {
                Queue<int> elozo = new Queue<int>();
                elozo.Enqueue(elem.Dequeue());
                

                //Console.WriteLine(this.csucsok[elozo.Peek()]);

                foreach (var item in elek)
	            {
                    int i  = 0;
                    if (item.Csucs1.Equals(elozo.Peek()) && !csucssorrend.Contains(item.Csucs2))
	                {
                        elem.Enqueue(item.Csucs2);
                        csucssorrend.Add(item.Csucs2);
                        i++;
                    }
	            }
	        } while (elem.Count != 0);
            return csucssorrend;
            /*

            List<int> csucssorrend= new List<int>();
            List<int> csucsokId = new List<int>();
            foreach (var item in csucsok)
	        {
                csucsokId.Add(item.getId());
	        }
            int elsocsucs = -1;
            for (int i = 0; i < 1; i++)
			{
                elsocsucs = i;
			}
            csucssorrend.Add(elsocsucs);
            Console.WriteLine(csucssorrend.Count+" asd");
            csucsokId.Clear();
            foreach (var item in elek)
            {
                if (item.Csucs1 == elsocsucs || item.Csucs2 == elsocsucs)
                {
                    if (!csucssorrend.Contains(item.Csucs1))
                    {
                        csucssorrend.Add(item.Csucs1);
                        csucsokId.Add(item.Csucs1);
                    }
                    else if(!csucssorrend.Contains(item.Csucs2))
                    {
                        csucssorrend.Add(item.Csucs2);
                        csucsokId.Add(item.Csucs2);
                    }
                }
	        }
            //while (false)
	        //{
                for (int i = csucsokId.IndexOf(2)+1; i < csucsokId.IndexOf(csucsokId.Count)+IndexOf(2)+1; i++)
			    {
                    Console.WriteLine(csucsokId.IndexOf(0));
                    Console.WriteLine(csucsokId.IndexOf(1));
                    Console.WriteLine(csucsokId.IndexOf(2)+1);
                    Console.WriteLine(csucsokId.IndexOf(3));
                    foreach (var item in elek)
                    {
                        if (item.Csucs1 == csucsokId.IndexOf(i)+1 || item.Csucs2 == csucsokId.IndexOf(i)+1)
                        {
                            if (!csucssorrend.Contains(item.Csucs1))
                            {
                                csucssorrend.Add(item.Csucs1);
                                csucsokId.Add(item.Csucs1);
                            }
                            else if(!csucssorrend.Contains(item.Csucs2))
                            {
                                csucssorrend.Add(item.Csucs2);
                                csucsokId.Add(item.Csucs2);
                            }
                        }
	                }
			    }
                foreach (var item in csucssorrend)
	{
                Console.WriteLine(item);
	}
                if (csucsok.Count == csucssorrend.Count)
	            {
                    //return csucssorrend;
                }
	        //}*/
        }
        

        public HashSet<int> mejsegibelyaras(int kezdo){
            HashSet<int> csucssorrend= new HashSet<int>();

            Stack<int> elem = new Stack<int>();
            elem.Push(kezdo);
            csucssorrend.Add(kezdo);

            do
	        {

                Stack<int> elozo = new Stack<int>();
                elozo.Push(elem.Pop());

                //Console.WriteLine(this.csucsok[elozo.Peek()]);

                foreach (var item in elek)
	            {
                    if (item.Csucs1.Equals(elozo.Peek()) && !csucssorrend.Contains(item.Csucs2))
	                {
                        elem.Push(item.Csucs2);
                        csucssorrend.Add(item.Csucs2);
	                }
	            }
	        } while (elem.Count != 0);
            return csucssorrend;
        }



        public bool bejarhato(int kezdo)
        {
            HashSet<int> csucssorrend= new HashSet<int>();

            Stack<int> elem = new Stack<int>();
            elem.Push(kezdo);
            csucssorrend.Add(kezdo);

            do
	        {

                Stack<int> elozo = new Stack<int>();
                elozo.Push(elem.Pop());

                //Console.WriteLine(this.csucsok[elozo.Peek()]);

                foreach (var item in elek)
	            {
                    if (item.Csucs1.Equals(elozo.Peek()) && !csucssorrend.Contains(item.Csucs2))
	                {
                        elem.Push(item.Csucs2);
                        csucssorrend.Add(item.Csucs2);
	                }
	            }
	        } while (elem.Count != 0);
            if (csucssorrend.Count == csucsok.Count)
            {
                return true;
            } else
	        {
                return false;
	        }
        }

        public Graf feszitoFa()
        {
            Graf fa= new Graf(this.csucsokSzama);

            HashSet<int> csucssorrend = new HashSet<int>();
            Queue<int> elem = new Queue<int>();

            elem.Enqueue(0);
            csucssorrend.Add(0);

            do
	        {

                Queue<int> elozo = new Queue<int>();
                elozo.Enqueue(elem.Dequeue());

                foreach (var item in elek)
	            {
                    if (item.Csucs1.Equals(elozo.Peek()))
	                {
                        if (csucssorrend.Contains(item.Csucs2))
	                    {
                            csucssorrend.Add(item.Csucs2);
                            elem.Enqueue(item.Csucs2);

                            fa.Hozzaad(item.Csucs1, item.Csucs2);
	                    }
	                }
	            }
	        } while (elem.Count != 0);


            return fa;
        }

        public override string ToString()
        {
            string str = "Csucsok:\n";
            foreach (var cs in csucsok)
            {
                
                str += cs + "\n";
            }
            str += "Elek:\n";
            foreach (var el in elek)
            {
                str += el + "\n";
            }
            return str;
        }
    }
}