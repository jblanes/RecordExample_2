﻿namespace BC.RecordUseExample.Backend.Infrastructure.DbModels
{
    // Notar como los campos del modelo de base de datos usan tipos de datos normales como DateTime o decimal
    public class Employee
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }


    }
}
