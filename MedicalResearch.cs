using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class UtilityManager
    {
        internal static string prompt(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        internal static int GetNumber(String question)
        {
            return int.Parse(prompt(question));
        }
    }
    class Disease
    {
        public string  DiseaseName { get; set; }
        public object  SymptomName { get; set; }
        public string PatientName { get; set; }
        public object  Severity { get; set; }
        public Object  Cause { get; set; }
        public string description { get; set; }     
    }

    class DiseaseManger
    {
       public static ArrayList list = null;
        private Disease[] _disease = null;
        private int _size = 0;
        public DiseaseManger(int size)
        {
            _size = size;
            _disease = new Disease[_size];
        }
        public void addDisease(Disease dis)
        {
            for (int i = 0; i < _size; i++)
            {
                if(_disease[i] == null)
                {
                    _disease[i] = new Disease {DiseaseName = dis.DiseaseName, Severity=dis.Severity,Cause=dis.Cause,description =dis.description };
                    
                }
            }
        }
        public void addSymptons(Disease dis)
        {
            for (int i = 0; i < _size; i++)
            {
                if(_disease[i] != null &&  _disease[i].DiseaseName == dis.DiseaseName)
                {
                    _disease[i].SymptomName = dis.SymptomName;

                    return;
                }
                else
                throw new Exception("This type of disease is not recorded");
                   
            }
        }
        public string checkPatient(string sym)
        {

            foreach (Disease dis in _disease)
            {
                if (dis.SymptomName != null )
                    return dis.DiseaseName;
            }
            //for (int i = 0; i < _size; i++)
            //{
            //    if(_disease[i].SymptomName !=null && _disease[i] ==dis.SymptomName )
            //    {
            //        foreach (var item in list)
            //        {
            //            dis.SymptomName = item;
            //        }
            //        return dis.DiseaseName;
            //    }
            //}
            throw new Exception("Symptons not able to regnoise");
        }
        
    }
    class DiseaseUI
    {
        enum SeverityOptions { high, medium, low };
        enum CauseOptions { External, Internal };

        public static DiseaseManger dmgr = null;
        public const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Medical Research Application ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\nAdd Disease Details -------------->Press 1\nAdd Symptom to Disease ----------->Press 2\nCheck Patient--------------------->press 3\n-------------------Press any key to Exit ----------------------------";
        public static void DisplayMenu()
        {
            int size = UtilityManager.GetNumber("Enter the Size");
            dmgr = new DiseaseManger(size);
            bool processing = true;
            do
            {
                int choice = Utilities.GetNumber(menu);
                processing = processsMenu(choice);
            } while(processing);
            Console.WriteLine("Thanks for visiting our application");
        }
        public static bool processsMenu(int choice)
        {
            switch(choice)
            {
                case 1:
                    addDiseaseHelper();
                    break;
                case 2:
                    addSymptomsHelper();
                 
                    break;
                case 3:
                    checkPatient();
                    return true;
                    break;


                default: return false;
            }
            return true;
        }
        public static void addDiseaseHelper()
        {
            string Name = UtilityManager.prompt("Enter the Name of the Disease :");

            Console.WriteLine("Enter the Severity of the Disease :");
            Array PossibleValues = Enum.GetValues(typeof(SeverityOptions));
            
            for (int i = 0; i < PossibleValues.Length; i++)
                Console.WriteLine(PossibleValues.GetValue(i));
            object inputValue = Enum.Parse(typeof(SeverityOptions), Console.ReadLine(), true);
            SeverityOptions SeverityOptions = (SeverityOptions)inputValue;

            Console.WriteLine("Enter the Cause of the Disease :");
            Array PossibleCauses = Enum.GetValues(typeof(CauseOptions));
            for (int i = 0; i < PossibleCauses.Length; i++)
                Console.WriteLine(PossibleCauses.GetValue(i));
            object input = Enum.Parse(typeof(CauseOptions), Console.ReadLine(), true);
            CauseOptions cause = (CauseOptions)input;

            string des = UtilityManager.prompt("Enter the Description of the Disease");
            Disease dis = new Disease { DiseaseName = Name, Severity = SeverityOptions,Cause = cause,description=des };

            dmgr.addDisease(dis);
            Console.WriteLine("Disease added Successfully");
        }
        public static void addSymptomsHelper()
        {
            string Name = UtilityManager.prompt("Enter the Name of the Disease :");
      
            string symptom = UtilityManager.prompt("Enter the Sympton");
             DiseaseManger.list = new ArrayList();
            DiseaseManger.list.Add(symptom);
            string des = UtilityManager.prompt("Enter the Description of the Disease");

            Disease dis = new Disease { DiseaseName = Name,SymptomName = DiseaseManger. list, description =des };

            dmgr.addSymptons(dis);
            Console.WriteLine("Symptoms added Successfully");
        }
        public static void checkPatient()
        {
            string PatientName = UtilityManager.prompt("Enter the Name of the Paient :");
            string symptom = UtilityManager.prompt("Enter the Sympton");
             string diseaseName = dmgr.checkPatient(symptom);
            string content = $"The Patient Name : {PatientName}\nSympton Name :{symptom}\nAnd the Possilbe Disease is : {diseaseName}" ;
            Console.WriteLine(content);
        }
    }
    class MedicalResearch
    {
        static void Main(string[] args)
        {
            DiseaseUI.DisplayMenu();
        }
    }
}
