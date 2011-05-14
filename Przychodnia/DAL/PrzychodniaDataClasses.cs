namespace DAL
{
    partial class PrzychodniaDataClassesDataContext
    {
    }

    partial class Uzytkownik
    {
        public override string ToString()
        {
            return this.imie + " " + this.nazwisko;
        }

        public string Name { get { return this.imie + " " + this.nazwisko; } }
    }

    partial class Kod_jednostki_grupa
    {
        public string Name { get { return this._kod + " - " + this._opis; } }
    }

    partial class Kod_jednostki_podgrupa
    {
        public string Name { get { return this._kod + " - " + this._opis; } }
    }

    partial class Kod_jednostki
    {
        public string Name { get { return this._kod + " - " + this._opis; } }
    }
}
