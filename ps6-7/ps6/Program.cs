using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.IO.Packaging;
using System.Net;

namespace ps6
{

    public enum Valence { I, II, III, IV,V } //перечисление валентности

    public class Atom : IClonable, IComparable<Atom>
    {
          string name;
        int countElectrons;
        string mass;
        Valence valence;

        public string Name
        {
            get { return name; }
            set 
            {
                if (value != null)
                    name= value;
                
            }
        }
        public int CountElectrons
        {
            get { return countElectrons; }
            set
            {
                if (value > 0)
                    countElectrons = value;
                else
                 
                    Console.WriteLine("Количество электронов должно быть больше нуля");
            }
        }
        public string Mass
        {
            get { return mass; }
            set { mass = value; }
        }
        public Valence valence_
        {
            get { return valence; }
            set { valence = value; }
        }
        public Atom()
        {
           

        }

        public Atom(string name, int countElectrons, string mass, Valence valence)
        {
            this.name = name;
            this.countElectrons = countElectrons;
            this.mass = mass;
            valence_ = valence;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Имя химического элемента: {Name}\n" +
                                  $"Количество электронов: {CountElectrons}\n" +
                                  $"Масса атома: {Mass}\n" +
                                  $"Валентность: {valence_}\n\n");
        }
        class RadioactiveAtom : Atom
        {
          public  string half_life;

          public  string Half_life
            {
                get { return half_life; }
                set { half_life = value; }
            }
            
            public RadioactiveAtom() { }

    public RadioactiveAtom(string name, int countElectrons, string mass, Valence valence, string half_life)
                    :base(name,countElectrons, mass, valence)
            {
                Half_life = half_life;
            }
            public override void GetInfo()
            {
               
                Console.WriteLine($"Имя химического элемента: {Name}\n" +
                              $"Количество электронов: {CountElectrons}\n" +
                              $"Масса атома: {Mass}\n" +
                              $"Валентность: {valence_}\n" +
                              $"Период полураспада: {Half_life}\n\n");
              
            }
        }
        public Atom Clone()
        {
            return new Atom(Name, CountElectrons,Mass, valence_);
        }
        public int CompareTo(Atom atom1)
        {
            if (atom1 == null) throw new ArgumentException("Некорректное значение параметра");
            return Name.CompareTo(atom1.Name);
        }
        static void Main(string[] args)
        {
            Atom atom = new Atom();
            atom.Name = "Водород";
            atom.CountElectrons = 2;
            atom.Mass = "12,011 а. е. м.";
            atom.valence_ = Valence.V;
            atom.GetInfo();

            RadioactiveAtom radioactiveAtom = new RadioactiveAtom();
            radioactiveAtom.Name = "Углерод";
            radioactiveAtom.CountElectrons = 3;
            radioactiveAtom.Mass = "12,011 а. е. м.";
            radioactiveAtom.valence_ = Valence.V;
            radioactiveAtom.Half_life = "5,70(3)⋅103 лет";
            radioactiveAtom.GetInfo();
            

            Console.WriteLine("Клон:\n");
            Atom copyAtom = atom.Clone();
            copyAtom.GetInfo();

            Console.WriteLine("Сравнение: " + atom.CompareTo(radioactiveAtom));
            Console.ReadLine();
        }
    }
}
