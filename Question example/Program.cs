using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Question_example
{
    class Program
    {
        static void Main(string[] args)
        {
      

            List<QuestionBlock> questionBlocks = new List<QuestionBlock>();
         

            int questionId = 0;
            string questionText = "";

            int answerid_1 = 0;
            string answerText_1 = "";
            string iscorrect_1 = "";
            int answerid_2 = 0;
            string answerText_2 = "";
            string iscorrect_2 = "";
            int answerid_3 = 0;
            string answerText_3 = "";
            string iscorrect_3 = "";
            int answerid_4 = 0;
            string answerText_4 = "";
            string iscorrect_4 = "";

            
            for (int i = 0; i < 2; i++)
            {
            
                Console.WriteLine("\n Enter id of question: \n");
                questionId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n Enter text of question: \n");
                questionText = Console.ReadLine();

                Console.WriteLine("\n");

                Console.WriteLine("\n Enter id of answer: \n");
                answerid_1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n Enter answer of question: \n");
                answerText_1 = Console.ReadLine();
                Console.WriteLine("\n Is answer correct?: \n");
                iscorrect_1 = Console.ReadLine();

                Console.WriteLine("\n Enter id of answer: \n");
                answerid_2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n Enter answer of question: \n");
                answerText_2 = Console.ReadLine();
                Console.WriteLine("\n Is answer correct?: \n");
                iscorrect_2 = Console.ReadLine();

                Console.WriteLine("\n Enter id of answer: \n");
                answerid_3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n Enter answer of question: \n");
                answerText_3 = Console.ReadLine();
                Console.WriteLine("\n Is answer correct?: \n");
                iscorrect_3 = Console.ReadLine();

                Console.WriteLine("\n Enter id of answer: \n");
                answerid_4 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n Enter answer of question: \n");
                answerText_4 = Console.ReadLine();
                Console.WriteLine("\n Is answer correct?: \n");
                iscorrect_4 = Console.ReadLine();

                 Add();


            }
                LoadandReadfromXML3();
                LoadandReadfromXML4();
            


             void Add()
            {

                questionBlocks.Add(new QuestionBlock(questionId, questionText)
                {
                    id = questionId,
                    Text = questionText,
                    Answers = new List<Answer>{

                           new Answer
                           {
                               id = answerid_1,
                               IsCorrect = iscorrect_1,
                               Text =answerText_1,
                           },

                           new Answer
                           {
                               id = answerid_2,
                               IsCorrect = iscorrect_2,
                               Text =answerText_2,
                           },

                           new Answer
                           {
                               id = answerid_3,
                               IsCorrect = iscorrect_3,
                               Text =answerText_3,
                           },

                           new Answer
                           {
                               id = answerid_4,
                               IsCorrect = iscorrect_4,
                               Text =answerText_4,
                           },

                    }




                });


                Console.WriteLine();

                var xml = new XmlSerializer(typeof(List<QuestionBlock>));
                DateTime d = DateTime.Now;
                using (var fs = new FileStream($"1.xml", FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, questionBlocks);
                }


                QuestionBlock questionBlock = null;

                var xml2 = new XmlSerializer(typeof(List<QuestionBlock>));

                using (var fs = new FileStream($"1.xml", FileMode.OpenOrCreate))
                {
                    questionBlock = xml2.Deserialize(fs) as QuestionBlock;

                }


                Console.Clear(); 

                foreach (var item in questionBlocks)
                {
                    Console.WriteLine(item.Text);
                    Console.WriteLine(item.id);

                 
                Console.WriteLine(item);
                }

                Thread.Sleep(2000);
                Console.Clear();

           

                XmlDocument doc = new XmlDocument();
                doc.Load($@"1.xml");
                XmlNodeList xmlNodeList = doc.GetElementsByTagName("Text");
                for (int i = 0; i < xmlNodeList.Count; i++)
                {

                    Console.WriteLine(xmlNodeList[i].InnerText.ToString());
                }

                Console.WriteLine(xmlNodeList[0].InnerText.ToString());
            }




            void LoadandReadfromXML4()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load($@"Data\QuestionsXML.xml");
                XmlNodeList xmlNodeList = doc.GetElementsByTagName("Answer");
                for (int i = 0; i < xmlNodeList.Count; i++)
                {

                    Console.WriteLine(xmlNodeList[i].Attributes["IsCorrect"].Value);
                }

                Console.WriteLine(xmlNodeList[0].Attributes["IsCorrect"].Value);
            }


            void LoadandReadfromXML3()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load($@"Data\QuestionsXML.xml");
                XmlNodeList xmlNodeList = doc.GetElementsByTagName("Text");
                for (int i = 0; i < xmlNodeList.Count; i++)
                {

                Console.WriteLine(xmlNodeList[i].InnerText.ToString());
                }

                Console.WriteLine(xmlNodeList[0].InnerText.ToString());
            }


            void LoadandReadfromXML1()
            {

                XmlDocument doc = new XmlDocument();
                doc.Load($@"Data\QuestionsXML.xml");
                string xmlcontents = doc.InnerXml;

                Console.WriteLine(xmlcontents);


                
            }

            void LoadandReadfromXML2()
            {
                XmlDocument doc2 = new XmlDocument();
                doc2.Load("C:\\Users\\Lenovo\\source\\repos\\Question example\\Question example\\bin\\Debug\\netcoreapp3.1\\QuestionsXML.xml");
                doc2.Save(Console.Out);
            }

        }
    }
}
