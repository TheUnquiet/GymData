using Assembly.Domain.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assembly.Domain.Models;

public class MemberDomain
{
    #region Constructors

    public MemberDomain(string firstName, string lastName, string email, string address, DateOnly birthday, string intrest, string memberType)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetEmail(email);
        SetAddress(address);
        SetBirthday(birthday);
        SetIntrest(intrest);
        SetMemberType(memberType);
    }

    public MemberDomain(int id, string firstName, string lastName, string email, string address, DateOnly birthday, string intrest, string memberType)
    {
        SetId(id);
        SetFirstName(firstName);
        SetLastName(lastName);
        SetEmail(email);
        SetAddress(address);
        SetBirthday(birthday);
        SetIntrest(intrest);
        SetMemberType(memberType);
    }

    #endregion

    #region Fields

    public int Id { get; private set; }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string Address { get; private set; } = string.Empty;

    public DateOnly Birthday { get; private set; }

    public string MemberType { get; private set; } = "";

    public string? Intressest { get; private set; }

    public List<CyclingssesionDomain> Cyclingssesions { get; private set; } = [];

    public List<RunningsessionMainDomain> RunningsessionMains { get; private set; } = [];

    public List<ReservationDomain> Reservations { get; private set; } = [];

    public List<ProgramDomain> ProgramCodes { get; private set; } = [];

    #endregion

    #region Methods

    public void SetId(int id) 
    {
        if (id <= 0)
        {
            MemberDomainException ex = new("Id is incorrect : ");
            ex.Data.Add("Id", id);
            throw ex;
        }

        Id = id;
    }

    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            MemberDomainException ex = new("FirstName is incorrect : ");
            ex.Data.Add("FirstName", firstName);
            throw ex;
        }

        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            MemberDomainException ex = new("LastName is incorrect : ");
            ex.Data.Add("LastName", lastName);
            throw ex;
        }

        LastName = lastName;
    }

    public void SetEmail(string email)
    {
        // https://stackoverflow.com/questions/5342375/regex-email-validation
        string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, emailRegex))
        {
            MemberDomainException ex = new("Email is empty or incorrect : ");
            ex.Data.Add("Email", email);
            throw ex;
        } else
        {
            Email = email;
        }
    }

    public void SetAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            MemberDomainException ex = new("Address is incorrect : ");
            ex.Data.Add("Address", address);
            throw ex;
        }

        Address = address;
    }

    public void SetBirthday(DateOnly birthday)
    {
        Birthday = birthday;
    }

    public void SetIntrest(string intrest)
    {
        Intressest = intrest;
    }

    public void SetMemberType(string memberType)
    {
        MemberType = memberType;
    }

    public void AddCyclingssesion(CyclingssesionDomain session)
    {
        if (session is null) throw new MemberDomainException("Session is empty");
        if (Cyclingssesions.Contains(session)) throw new MemberDomainException("Session already added");
        Cyclingssesions.Add(session);
    }

    public void RemoveCyclingssesion(CyclingssesionDomain session)
    {
        if (session is null) throw new MemberDomainException("Session is empty");
        if (!Cyclingssesions.Contains(session)) throw new MemberDomainException("Session not found");
        Cyclingssesions.Remove(session);
    }

    public void AddReservations(ReservationDomain reservation)
    {
        if (reservation is null) throw new MemberDomainException("Reservation is empty");
        if (Reservations.Contains(reservation)) throw new MemberDomainException("Reservation already added");
        Reservations.Add(reservation);
    }

    public void RemoveReservation(ReservationDomain reservation)
    {
        if (reservation is null) throw new MemberDomainException("Session is empty");
        if (!Reservations.Contains(reservation)) throw new MemberDomainException("Session not found");
        Reservations.Remove(reservation);
    }

    public void AddRunningRunningSession(RunningsessionMainDomain session)
    {
        if (session is null) throw new MemberDomainException("Session is empty");
        if (RunningsessionMains.Contains(session)) throw new MemberDomainException("Session already added");
        RunningsessionMains.Add(session);
    }

    public void RemoveRunningSession(RunningsessionMainDomain session)
    {
        if (session is null) throw new MemberDomainException("Session is empty");
        if (!RunningsessionMains.Contains(session)) throw new MemberDomainException("Session not found");
        RunningsessionMains.Remove(session);
    }

    public void AddProgram(ProgramDomain program)
    {
        if (program is null) throw new MemberDomainException("Session is empty");
        if (ProgramCodes.Contains(program)) throw new MemberDomainException("Session already added");
        ProgramCodes.Add(program);
    }

    public void RemoveProgram(ProgramDomain program)
    {
        if (program is null) throw new MemberDomainException("Session is empty");
        if (!ProgramCodes.Contains(program)) throw new MemberDomainException("Session not found");
        ProgramCodes.Remove(program);
    }

    #endregion
}