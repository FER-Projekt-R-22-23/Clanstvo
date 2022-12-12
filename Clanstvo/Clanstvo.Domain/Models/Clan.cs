﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clanstvo.Domain.Models;
public class Clan : AggregateRoot<int>
{
    private string _ime;
    private string _prezime;
    private DateTime _datumRodenja;
    private byte[]? _slika;
    private string _adresa;
    private bool _imaMaramu;
    private DateTime? _datumMarama;
    private string? _mjestoMarama;


    public string Ime { get => _ime; set => _ime = value; }
    public string Prezime { get => _prezime; set => _prezime = value; }
    public DateTime DatumRodenja { get => _datumRodenja; set => _datumRodenja = value; }
    public byte[]? Slika { get => _slika; set => _slika = value; }
    public string Adresa { get => _adresa; set => _adresa = value; }
    public bool ImaMaramu { get => _imaMaramu; set => _imaMaramu = value; }
    public DateTime? DatumMarama { get => _datumMarama; set => _datumMarama = value; }
    public string? MjestoMarama { get => _mjestoMarama; set => _mjestoMarama = value; }

    public Clan(int id, string ime, string prezime, DateTime datumRodenja,
                      byte[] slika, string adresa, bool imaMaramu, DateTime? datumMarama, string mjestoMarama) : base(id)
    {
        if (string.IsNullOrEmpty(ime))
        {
            throw new ArgumentException($"'{nameof(ime)}' cannot be null or empty.", nameof(ime));
        }

        if (string.IsNullOrEmpty(prezime))
        {
            throw new ArgumentException($"'{nameof(prezime)}' cannot be null or empty.", nameof(prezime));
        }

        if (datumRodenja == DateTime.MinValue)
        {
            throw new ArgumentException($"'{nameof(datumRodenja)}' cannot be null or empty.", nameof(datumRodenja));
        }


        if (string.IsNullOrEmpty(adresa))
        {
            throw new ArgumentException($"'{nameof(adresa)}' cannot be null or empty.", nameof(adresa));
        }


        _ime = ime;
        _prezime = prezime;
        _datumRodenja = datumRodenja;
        _slika = slika;
        _adresa = adresa;
        _imaMaramu = imaMaramu;
        _datumMarama = datumMarama;
        _mjestoMarama = mjestoMarama;

    }

    public override bool Equals(object? obj)
    {
        return obj is not null &&
                obj is Clan clan &&
                _id == clan._id &&
                _ime == clan._ime &&
                _prezime == clan._prezime &&
                _datumRodenja == clan._datumRodenja &&
                _slika == clan._slika &&
                _adresa == clan._adresa &&
                _imaMaramu == clan._imaMaramu &&
                _datumMarama == clan._datumMarama &&
                _mjestoMarama == clan._mjestoMarama;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_ime, _prezime, _datumRodenja, _slika, _adresa, _imaMaramu, _datumRodenja, _mjestoMarama);
        // bez _id u funkciji jer moze uzimati max 8 varijabli
    }

}


    /* public override Result IsValid()
         => Validation.Validate(
             (() => _ime.Length <= 50, "Ime lenght must be less than 50 characters"),
             (() => _prezime.Length <= 50, "Prezime lenght must be less than 50 characters"),
             (() => !string.IsNullOrEmpty(_ime.Trim()), "Ime can't be null, empty, or whitespace"),
             (() => !string.IsNullOrEmpty(_prezime.Trim()), "Prezime can't be null, empty, or whitespace")
             (() => datumRodenja == DateTime.MinValue, "DatumRodenja can't be default value")
             );
     */