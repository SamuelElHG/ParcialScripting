using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace TestProject1
{
    internal class TestMethods
    {
        internal enum EValueType
        {
            Two,
            Three,
            Five,
            Seven,
            Prime
        }

        internal static Stack<int> GetNextGreaterValue(Stack<int> sourceStack)
        {


            Stack<int> copia1 = new Stack<int>();
            Stack<int> copia2 = new Stack<int>();
            List<int> copia = new List<int>();

            copia = sourceStack.ToList();//para duplicar un stack, toca cambiarlo por una estructura diferente
                                         //ahora queremos una copia en stack, así que toca pasarlo 2 veces
            for (int i = 0; i < copia.Count; i++)
            {
                copia2.Push(copia[i]);
            }
            while (copia2.Count>0)
            {
                copia1.Push(copia2.Pop()); //ahora en copia1 hay una copia del arreglo original
            }
            for (int i = 0; i < copia.Count; i++)
            {
                copia2.Push(copia[i]);//también tengo una al revés
            }
            int numactual = 0;
            int numMayor = 0;

            Stack<int> resultTemporal = new Stack<int>();
            Stack<int> result = new Stack<int>();


            while (copia1.Count>0)
            {
                numactual = copia1.Pop();//tomo el primer número invertido, o el del fondo del stack
                if (numactual>numMayor) //verifico si es el número mayor
                {
                    numMayor = numactual;
                }
                
                    if (numMayor==numactual)
                 {
                        resultTemporal.Push(-1);
                     
                 }
                else
                {
                    resultTemporal.Push(numMayor);
                }
                
            }
            while (resultTemporal.Count>0) //como vamos desde el último al primero, el stack nos queda invertido. Como checamos si el último es mayor al que tiene debajo, y eso lo guardamos, queda al revés
            {
                result.Push(resultTemporal.Pop());
            }

            return result;
        }//malo

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>(); //resultado a entregar

            for (int i = 0; i < sourceArr.Length; i++)//recorremos la copia. Usamos ifs anidados para que se cumpla la primera condición. el % sirve y es bastante simple
            {
                if (sourceArr[i] % 2==0)
                {
                    result.Add(sourceArr[i], EValueType.Two);
                }
                else
                {
                    if (sourceArr[i] % 3 == 0)
                    {
                        result.Add(sourceArr[i], EValueType.Three);
                    }
                    else
                    {
                        if (sourceArr[i] % 5 == 0)
                        {
                            result.Add(sourceArr[i], EValueType.Five);

                        }
                        else
                        {
                            if (sourceArr[i] % 7 == 0)
                            {
                                result.Add(sourceArr[i], EValueType.Seven);

                            }
                            else
                            {
                                result.Add(sourceArr[i], EValueType.Prime);

                            }
                        }
                    }

                }
            }


            return result;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type) //contar cuántos con un valor determinado, bueno
        {
            int result = 0; //contador de resultado a entregar al problema

            foreach (var item in sourceDict) //nos entregan un enum de un tipo, solo es recorrer el diccionario y aumentar el contador si la LLAVE es igual a la que nos dan. El "valor" no es relevante aquí
            {
                if (item.Value == type)
                {
                    result++;
                }
            }

            return result;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)//ordenar, bueno, revisar el for
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>(); //Diccionario a entregar al problema

           int[] llaves = new int[sourceDict.Count];//tenemos un arreglo del tamaño del diccionario
            EValueType[] valor = new EValueType[sourceDict.Count]; 
            int h = 0;
            foreach (var item in sourceDict) //llenamos las llaves con las llaves y los valores con los valores. Ahora están parejos pero no ordenados
            {
                llaves[h] = item.Key;
                valor[h] = item.Value;
                h++;
            }
            for (int i = 0; i < llaves.Length; i++) //es un for anidado para ordenar arreglos. Si pudiéramos usaríamos el array.sort
            {
                for (int k = 0; k < llaves.Length - 1; k++)
                {
                    int sigLlave = llaves[k + 1];
                    EValueType sigValor = valor[k + 1];

                    if (llaves[k] < sigLlave)
                    {
                        llaves[k + 1] = llaves[k];
                        llaves[k] = sigLlave;

                        valor[k + 1] = valor[k];
                        valor[k] = sigValor;
                    }
                }
            }
            //volvemos al diccionario que debemos entregar y lo llenamos, los números son las llaves y los valores los enum
            for (int k = 0; k < llaves.Length; k++)
            {
                result.Add(llaves[k], valor[k]);
            }
                return result; //Entregar el resultado
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)//bueno, revisar
        {
            Queue<Ticket>[] result = new Queue<Ticket>[3]; //Arrelgo de 3 colas en paralelo, es una estructura ticket vectorial


            //Inicializar las 3 colas que irán en el array de queues
            Queue<Ticket> payment = new Queue<Ticket>();
            Queue<Ticket> subscription = new Queue<Ticket>();
            Queue<Ticket> cancellation = new Queue<Ticket>();



            //organizamos usando el for anidado como antes

            for (int i = 0; i < sourceList.Count; i++)
            {
                for (int k = 0; k < sourceList.Count - 1; k++)
                {
                    int nextTurn = sourceList[k + 1].Turn;
                    Ticket nextTicket = sourceList[k + 1];

                    if (sourceList[k].Turn > nextTurn)
                    {
                        sourceList[k + 1] = sourceList[k];
                        sourceList[k] = nextTicket;
                    }
                }
            }

            //Ya que los turnos ya están ordenados, se puede proceder a asignar los turnos
            //a los queues de su tipo correspondiente (y estos ya estarán ordenados)
            for (int i = 0; i < sourceList.Count; i++)
            {
                if (sourceList[i].RequestType == Ticket.ERequestType.Payment)
                { 
                    payment.Enqueue(sourceList[i]);
                }
                if (sourceList[i].RequestType == Ticket.ERequestType.Subscription) 
                { 
                    subscription.Enqueue(sourceList[i]);
                }
                if (sourceList[i].RequestType == Ticket.ERequestType.Cancellation) 
                {
                    cancellation.Enqueue(sourceList[i]);
                }
            }

            //Una vez ya todos los turnos están en sus repectivas queues
            //se guardan las queues en el orden requerido en el array
            result[0] = payment;
            result[1] = subscription;
            result[2] = cancellation;

            return result;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result = false;

            //ticket tiene la variable turno, que está entre 1 y 99
            //recibo una queue con la queue que me quiero meter y el número de ticket
            /*la estructura Ticket ticket recibe la cola a la que quiere acceder y el turno.
             * la cola es un Enum, y la queue TargetQue recordamos que es un arreglo de colas que tiene los enum
             * 
             si la cola "request type" a la que quiere acceder es alguna de la Enum y el turno está entre 1 y 99, se le asigna el turno*/
            if (ticket.RequestType==targetQueue.Peek().RequestType && ticket.Turn >0 && ticket.Turn<100)
            {
                result = true;
            }
            return result;
        }        
    }
}