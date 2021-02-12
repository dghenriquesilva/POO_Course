using System;
using System.Collections.Generic;
using System.Text;
using Composition.Entities.Enums;

namespace Composition.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        // Composição da classe Department
        public  Department Department{ get; set; }
        // Composição da classe HourContracts (Aqui será uma lista de contratos)
        // Já instanciada para garantir que não seja nula
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        // Construtores
        public Worker()
        {
        }

        // Não adicionar o Contracts porque não é usual passar uma lista instanciada em um construtor de um objeto
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        // Metodos (com associação entre objetos)
        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach(HourContract contract in Contracts)
            {
                if (contract.Date.Year ==year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}
