using System;
using System.Collections.Generic;

namespace testPayDate
{
    class Program
    {
            /*
     * Esercizio: implementare un sistema di Payroll.
     * Un trigger chiama l'applicazione ogni giorno alle 23:59.
     * L'applicazione itera su tutti gli impiegati registrati,
     *     e in caso sia il loro giorno di paga, calcola la paga e registra un record con il pagamento.
     * Gli impiegati di base hanno Id e Nome. Sono di 3 tipi:
     * 1) A salario fisso
     *     - hanno una proprietà con il salario fisso mensile;
     *     - il giorno di paga è l'ultimo del mese.
     * 2) A ore
     *     - hanno una paga oraria, e un elenco di record che registra per ogni giorno lavorato il numero di ore lavorate;
     *     - il giorno di paga è sempre il sabato, e calcola la paga dei giorni lun-ven della settimana corrente;
     * 3) A commissione
     *     - la paga è una percentuale sulle vendite effettuate; hanno un elenco di record con l'ammontare di una vendita e la data.
     *     - la paga è giorno per giorno, sulle vendite di quel giorno.
     *     
     * Nel Main() è illustrato l'algoritmo che si vuole ottenere.
     */
        static void Main(string[] args)
        {
            /*
            lista di impiegati creata come mock
            per ogni impiegato della lista
               se è il suo giorno di paga
                   calcola la sua paga
                   crea un record con l'id dell'impiegato, la paga, e la data di oggi
                   aggiungi alla lista di record 
             */
            List<Employee> getMockEmployees = GetMockEmployees();
            

        }


        interface IFilter<T>
        {
            bool IsPayDayLastOfTheMonth(IList<Employee> list, T input);

            List<Employee> FilterEmployee(IList<Employee> list, T input);
        }

        
        

        public static List<Employee> GetMockEmployees()
        {
            return new List<Employee>()
            {
                new Employee(1, "Mario Rossi"),
                new Employee(2, "Gigi LaTrottola"),
                new Employee(3, "Rosenkrantz MyGrandma")
            };
            
        }
    }
    class Employee
    {
        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }

    class FixedSalaryEmployee 
    {    
        public decimal FixedMonthlySalary { get; set; }
        public bool IsPayDayLastOfTheMonth { get; set; }
    }
    class HourPaidEmployee
    {

    }

    class CommissionPaidEmployee
    {

    }

}
