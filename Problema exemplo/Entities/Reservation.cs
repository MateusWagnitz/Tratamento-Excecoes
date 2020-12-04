using System;
using Problema_exemplo.Entities.Exceptions;


namespace Problema_exemplo.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation()
        {

        }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new DomainException("Error in reservation:  Reservation dates for update must be future dates");
            }
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        #region UpdateDates resolução 1
        //public void UpdateDates(DateTime checkIn, DateTime checkOut)
        //{
        //    CheckIn = checkIn;
        //    CheckOut = checkOut;
        //}
        #endregion

        #region UpdateDates resolução 2
        //public string UpdateDates(DateTime checkIn, DateTime checkOut)
        //{
        //    DateTime now = DateTime.Now;
        //    if (checkIn < now || checkOut < now)
        //    {
        //        return "Reservation dates for update must be future dates";
        //    }
        //    if (checkOut <= checkIn)
        //    {
        //       return "Error in reservation:  Reservation dates for update must be future dates";
        //    }

        //    CheckIn = checkIn;
        //    CheckOut = checkOut;
        //    return null;
        //}
        #endregion

        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;
            if (checkIn < now || checkOut < now)
            {
                throw new DomainException("Reservation dates for update must be future dates"); // jogando uma nova excessão
            }                                                                                   // corta o método igual o return
            if (checkOut <= checkIn)
            {
                throw new DomainException("Error in reservation:  Reservation dates for update must be future dates");
            }

            CheckIn = checkIn;
            CheckOut = checkOut;
            
        }
        public override string ToString()
        {
            return "Room"
                + RoomNumber
                + ", chek-in"
                + CheckIn.ToString("dd/MM/yyyy")
                + ", check-out: "
                + CheckOut.ToString("dd/MM/yyyy")
                + ", "
                + Duration()
                + " nights";

        }
    }
}
