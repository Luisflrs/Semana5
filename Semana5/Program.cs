using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            bool showmenu = true;

            while (showmenu)
            {
                showmenu = menu();

            }

            Console.ReadKey();
        }

        private static bool menu()
        {

            Console.WriteLine("Listado de empleados de la empresa Lunotopia)";
            Console.WriteLine("Seleccione una opción");
            Console.WriteLine("1- agregar datos");
            Console.WriteLine("2- editar datos");
            Console.WriteLine("3- mostrar datos registrados");
            Console.WriteLine("4- salir");
            Console.Write("\nOpción: ");


            switch (Console.ReadLine())
            {
                case "1":
                    register();
                    return true;
                case "2":
                    update();
                    Console.ReadKey();
                    return true;
                case "3":
                    Console.WriteLine("Lista de empleados de laboratorios star");
                    foreach (KeyValuePair<object, object> data in readFile())
                    {
                        Console.WriteLine("{0}; {1}", data.Key, data.Value);
                    }
                    Console.ReadKey();
                    return true;
                case "4":
                    return false;
                default:
                    return false;


            }
        }
        private static string getPaht()
        {
            string paht = @"C:\ejercicio5\Empleados.txt";
            return paht;
        }

        private static void register()
        {
            Console.WriteLine("Datos de el empleado");
            Console.WriteLine("Nombre completo: ");
            string FullName = Console.ReadLine();
            Console.WriteLine("Puesto de el empleado: ");
            string puesto = Console.ReadLine();

            using (StreamWriter sw = File.AppendText(getPaht()))
            {
                sw.WriteLine("{0}; {1}", FullName, puesto);
                sw.Close();
            }

        }

        private static Dictionary<object, object> readFile()
        {
            Dictionary<object, object> listData = new Dictionary<object, object>();

            using (var lectura = new StreamReader(getPaht()))
            {
                string lineas;
                while ((lineas = lectura.ReadLine()) != null)
                {
                    string[] KeyValue = lineas.Split(';');
                    if (KeyValue.Length == 2)
                    {
                        listData.Add(KeyValue[0], KeyValue[1]);
                    }
                }

            }

            return listData;
        }


        private static bool search(string name)
        {
            if (!readFile().ContainsKey(name))
            {
                return false;
            }
            return true;
        }

        private static void update()
        {
            Console.WriteLine("Escriba el nombre completo de el empleado que desea actualizar: ");
            var name = Console.ReadLine();





            if (search(name))
            {
                Console.WriteLine("El regitro se ha encontrado ");
                Console.WriteLine("Ingrese el nuevo puesto para el empleado");
                var newPuesto = Console.ReadLine();


                Dictionary<object, object> temp = new Dictionary<object, object>();
                temp = readFile();

                temp[name] = newPuesto;
                Console.WriteLine("El dato se ha actualizado");
                File.Delete(getPaht());

                using (StreamWriter sw = File.AppendText(getPaht()))
                {
                    foreach (KeyValuePair<object, object> values in temp)
                    {
                        sw.WriteLine("{0}; {1}", values.Key, values.Value);

                    }


                }
            }
            else
            {

                Console.WriteLine("El registro no existe");
            }
        }
    }