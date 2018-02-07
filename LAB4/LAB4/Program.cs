using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationExamples
{
    class Program
    {
        static void F1()
        {
            FileStream fs = new FileStream(@"C:\Users\Adilkhan\Desktop\PP\LAB4\LAB4\data1.xml", FileMode.Create, FileAccess.Write);

            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex s = new Complex();
            try
            {
                xs.Serialize(fs, s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }

            Console.WriteLine("done");
        }


        static void F2()
        {
            FileStream fs = new FileStream(@"C:\Users\Adilkhan\Desktop\PP\LAB4\LAB4\data1.xml", FileMode.Open, FileAccess.Read);

            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            try
            {
                Complex s = xs.Deserialize(fs) as Complex;

                Console.WriteLine(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }


        }
        static void f1()
        {
            FileStream fs = new FileStream(@"C:\Users\Adilkhan\Desktop\PP\LAB4\LAB4\data.ser", FileMode.Create, FileAccess.Write);

            Complex s = new Complex();
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }

            Console.WriteLine("done");
        }

        static void f2()
        {
            FileStream fs = new FileStream(@"C:\Users\Adilkhan\Desktop\PP\LAB4\LAB4\data.ser", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                Complex s = (Complex)bf.Deserialize(fs);

                Console.WriteLine(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        static void Main(string[] args)
        {
            F1();
            //f2();
            Console.ReadKey();
        }
    }
}