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

}
