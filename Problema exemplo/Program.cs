#region Enunciado problema
//Fazer um programa para ler os dados de uma reserva de hotel (número do quarto, data
//de entrada e data de saída) e mostrar os dados da reserva, inclusive sua duração em
//dias. Em seguida, ler novas datas de entrada e saída, atualizar a reserva, e mostrar
//novamente a reserva com os dados atualizados. O programa não deve aceitar dados
//inválidos para a reserva, conforme as seguintes regras:
//-Alterações de reserva só podem ocorrer para datas futuras
//- A data de saída deve ser maior que a data de entrada
#endregion

#region Exemplos de output
//Room number: 8021
//Check -in date(dd / MM / yyyy): 23 / 09 / 2019
//Check -out date(dd / MM / yyyy): 26 / 09 / 2019
//Reservation: Room 8021, check -in: 23 / 09 / 2019, check -out: 26 / 09 / 2019, 3 nights
//          Enter data to update the reservation:
//Check -in date(dd / MM / yyyy): 24 / 09 / 2019
//Check -out date(dd / MM / yyyy): 29 / 09 / 2019
//Reservation: Room 8021, check -in: 24 / 09 / 2019, check -out: 29 / 09 / 2019, 5 nights
#endregion

using System;
using Problema_exemplo.Entities;
using Problema_exemplo.Entities.Exceptions;

namespace Problema_exemplo
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Solução muito ruim (com if e else sem delegações)

            //• Solução 1 (muito ruim): lógica de validação no programa principal
            //• Lógica de validação não delegada à reserva

            //Console.WriteLine("Room number: ");
            //int number = int.Parse(Console.ReadLine());
            //Console.WriteLine("Check-in date(dd / MM / yyyy)");
            //DateTime checkIn = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine("Check-out date(dd / MM / yyyy)");
            //DateTime checkOut = DateTime.Parse(Console.ReadLine());

            //if (checkOut <= checkIn)
            //{
            //    Console.WriteLine("Error in reservation: Check-out date must be after check-in date");
            //}
            //else
            //{
            //    Reservation reservation = new Reservation(number, checkIn, checkOut);
            //    Console.WriteLine("Reservation: " + reservation);

            //    Console.WriteLine();
            //    Console.WriteLine("Enter data to update the reservation:");
            //    Console.WriteLine("Check-in date(dd / MM / yyyy)");
            //    checkIn = DateTime.Parse(Console.ReadLine());
            //    Console.WriteLine("Check-out date(dd / MM / yyyy)");
            //    checkOut = DateTime.Parse(Console.ReadLine());

            //    DateTime now = DateTime.Now;
            //    if (checkIn < now || checkOut < now)
            //    {
            //        Console.WriteLine("Error in reservation:  Reservation dates for update must be future dates");
            //    }
            //    else if(checkOut <= checkIn)
            //    {
            //        Console.WriteLine("Error in reservation:  Reservation dates for update must be future dates");
            //    }
            //    else
            //    {
            //        reservation.UpdateDates(checkIn, checkOut);
            //        Console.WriteLine("Reservation: " + reservation);
            //    }

            //}
            #endregion

            #region Solução ruim (método retornando string)

            //• Solução 2(ruim): método retornando string
            //• A semântica da operação é prejudicada
            //• Retornar string não tem nada a ver com atualização de reserva
            //• E se a operação tivesse que retornar um string?
            //• Ainda não é possível tratar exceções em construtores
            //• A lógica fica estruturada em condicionais aninhadas


            //Console.WriteLine("Room number: ");
            //int number = int.Parse(Console.ReadLine());
            //Console.WriteLine("Check-in date(dd / MM / yyyy)");
            //DateTime checkIn = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine("Check-out date(dd / MM / yyyy)");
            //DateTime checkOut = DateTime.Parse(Console.ReadLine());

            //if (checkOut <= checkIn)
            //{
            //    Console.WriteLine("Error in reservation: Check-out date must be after check-in date");
            //}
            //else
            //{
            //    Reservation reservation = new Reservation(number, checkIn, checkOut);
            //    Console.WriteLine("Reservation: " + reservation);

            //    Console.WriteLine();
            //    Console.WriteLine("Enter data to update the reservation:");
            //    Console.WriteLine("Check-in date(dd / MM / yyyy)");
            //    checkIn = DateTime.Parse(Console.ReadLine());
            //    Console.WriteLine("Check-out date(dd / MM / yyyy)");
            //    checkOut = DateTime.Parse(Console.ReadLine());

            //    string error = reservation.UpdateDates(checkIn, checkOut);

            //    if(error != null)
            //    {
            //        Console.WriteLine("Error in reservation" + error);
            //    }

            //    else
            //    {                    
            //        Console.WriteLine("Reservation: " + reservation);
            //    }

            //}
            #endregion

            #region Solução boa
            try
            {
                Console.Write("Room number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                Reservation reservation = new Reservation(number, checkIn, checkOut);
                Console.WriteLine("Reservation: " + reservation);

                Console.WriteLine();
                Console.WriteLine("Enter data to update the reservation:");
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                reservation.UpdateDates(checkIn, checkOut);
                Console.WriteLine("Reservation: " + reservation);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error in format: " + e.Message);
            }
            catch (DomainException e)
            {
                Console.WriteLine("Error in reservation: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }


        #endregion
    }
    
}
