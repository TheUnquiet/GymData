using Assembly.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Models
{
    public class EquipmentDomain
    {
        #region Constructor

        public EquipmentDomain(int equipmentId, string deviceType)
        {
            SetId(equipmentId);
            SetDeviceType(deviceType);
        }

        public EquipmentDomain(string deviceType)
        {
            SetDeviceType(deviceType);
        }

        #endregion

        #region Fields

        public int EquipmentId { get; set; }

        public string DeviceType { get; set; } = "";

        public virtual List<ReservationDomain> Reservations { get; set; } = new List<ReservationDomain>();

        #endregion

        #region Methods

        public void SetId(int id)
        {
            if (id <= 0)
            {
                EquipmentDomainException ex = new EquipmentDomainException("Id is incorrect");
                ex.Data.Add("id", id);
                throw ex;
            }

            EquipmentId = id;
        }

        public void SetDeviceType(string deviceType)
        {
            DeviceType = deviceType;
        }

        public void AddReservation(ReservationDomain reservation)
        {
            if (reservation == null) throw new EquipmentDomainException("Reservation is empty");
            if (Reservations.Contains(reservation)) throw new EquipmentDomainException("Reservation already added");
            Reservations.Add(reservation);
        }

        public void RemoveReservation(ReservationDomain reservation)
        {
            if (reservation == null) throw new EquipmentDomainException("Reservation is empty");
            if (!Reservations.Contains(reservation)) throw new EquipmentDomainException("Reservation is not in the list");
            Reservations.Remove(reservation);
        }

        #endregion
    }
}
