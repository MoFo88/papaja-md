using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data.Linq;
using System.Security.Cryptography;

namespace BLL
{
    public class Repository
    {
        public static List<Lekarz> GetAllDoctors()
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();
            var query = from u in ctx.Uzytkowniks.OfType<Lekarz>() select u;


            return query.ToList();
        }

        
        public static List<Pacjent> GetAllPatients()
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();
            var query = from u in ctx.Uzytkowniks.OfType<Pacjent>() select u;

            return query.ToList();
        }

        public static List<Pacjent> GetAllDrPatients(int id)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();
            var query = from c in ctx.Uzytkowniks.OfType<Lekarz>() where c.id == id select c;
            Lekarz lek = query.First();          

            return lek.Pacjents.ToList();
        }

        public static List<Specjalizacja> GetAllSpecjalizations()
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();

            var query = from c in ctx.Specjalizacjas select c;
            return query.ToList();
        }

        public static void DeleteUser(int userId)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();

            Uzytkownik user = ctx.Uzytkowniks.SingleOrDefault( u => u.id == userId );

            ctx.Uzytkowniks.DeleteOnSubmit(user);

            ctx.SubmitChanges();

        }

       
        public static bool AddNewDoctor(String imie, String nazwisko, String email, String kodPocztowy, String miasto, string nrDomu, decimal pesel, string telefon, string ulica, List<int> idsSpecjalizacja, String login, String password)
        {

            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();

            var query = from u in ctx.Uzytkowniks where u.login == login select u;

            Uzytkownik user = query.SingleOrDefault();

            if (user != null)
            {
                throw new UserExistException();
            }

            String passSHA1 = CalculateSHA1(password, Encoding.ASCII);

            Lekarz l = new Lekarz()
            {
                imie = imie,
                nazwisko = nazwisko,
                email = email,
                kod_pocztowy = kodPocztowy,
                miasto = miasto,
                nr_domu = nrDomu,
                pesel = pesel,
                telefon = telefon,
                ulica = ulica,
                login = login,
                password = passSHA1
                
            };

            List<Specjalizacja_Lekarz> list = new List<Specjalizacja_Lekarz>();
            foreach (int i in idsSpecjalizacja)
            {
                Specjalizacja_Lekarz s = new Specjalizacja_Lekarz()
                {
                    idSpecjalizacja = i
                };
                list.Add(s);

            }

            l.Specjalizacja_Lekarzs.AddRange(list);


            ctx.Uzytkowniks.InsertOnSubmit(l);
            ctx.SubmitChanges();

            return true;
        }

        public static bool AddNewPatient(String imie, String nazwisko, String kodPocztowy, String miasto, string nrDomu, decimal? pesel, string telefon, string ulica,  int? idDr)
        {

            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();

            Pacjent p = new Pacjent()
            {
                imie = imie,
                nazwisko = nazwisko,
                kod_pocztowy = kodPocztowy,
                miasto = miasto,
                nr_domu = nrDomu,
                pesel = pesel,
                telefon = telefon,
                ulica = ulica

            };

            p.id_lek = idDr;

            ctx.Uzytkowniks.InsertOnSubmit(p);
            ctx.SubmitChanges();

            return true;
        }

        public static bool AddNewSpecialization(string name)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();

            Specjalizacja s = new Specjalizacja()
            {
                nazwa = name
            };

            ctx.Specjalizacjas.InsertOnSubmit(s);
            ctx.SubmitChanges();

            return true; 
        }

        public static Specjalizacja GetSpecializationById(int id)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();

            var query = from c in ctx.Specjalizacjas where c.id == id select c;

            return query.First();
        }

        public static string CalculateSHA1(string text, Encoding enc)
        {
            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();           
            string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).ToLower().Replace("-", "");
            return hash;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pswd"></param>
        /// <returns></returns>
        /// <exception cref="NoUserException">NoUserException</exception>
        public static Uzytkownik UserAuth(string login, string pswd)
        {

            String pass = CalculateSHA1(pswd, Encoding.ASCII);
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();
            
            var query = from u in ctx.Uzytkowniks
                        where u.login == login && u.password == pass
                        select u;
            
            Uzytkownik user = query.FirstOrDefault();

            if (user == null)
            {
                throw new NoUserException();
            }

            return user;
        }

        public static Uzytkownik GetUserByID(int id)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();

            var query = from u in ctx.Uzytkowniks
                        where u.id == id
                        select u;

            return query.SingleOrDefault();
        }

        public static List<Specjalizacja> GetAllDrSpecjalizations(Lekarz dr)
        {
            List<Specjalizacja> specList = new List<Specjalizacja>();

            foreach (Specjalizacja_Lekarz sl in dr.Specjalizacja_Lekarzs)
            {
                specList.Add(Repository.GetSpecializationById(sl.idSpecjalizacja));
            }

            return specList;
        }

        public static void UpdateUserData(Uzytkownik user, String imie, String nazwisko, String kodPocztowy, String miasto, string nrDomu, Decimal? pesel, string telefon, string ulica, String login)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();

            if (login != null)
            {
                if (login != user.login)
                {
                    var query = from u in ctx.Uzytkowniks where u.login == login select u;

                    Uzytkownik us = query.SingleOrDefault();

                    if (us != null)
                    {
                        throw new UserExistException();
                    }
                }
            }

            var query2 = from u in ctx.Uzytkowniks where u.id == user.id select u;
            Uzytkownik usr = query2.SingleOrDefault();

            usr.imie = imie;
            usr.nazwisko = nazwisko;
            usr.kod_pocztowy = kodPocztowy;
            usr.miasto = miasto;
            usr.nr_domu = nrDomu;
            usr.telefon = telefon;
            usr.ulica = ulica;
            usr.login = login;
            usr.pesel = pesel;

            ctx.SubmitChanges();
        }

        
        public static void UpdateDrData(Lekarz dr, String imie, String nazwisko, String email, String kodPocztowy, String miasto, string nrDomu, Decimal? pesel, string telefon, string ulica, List<int> idsSpecjalizacja, String login)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();
            Repository.UpdateUserData(dr, imie, nazwisko, kodPocztowy, miasto, nrDomu, pesel, telefon, ulica, login);

            var query = from u in ctx.Uzytkowniks.OfType<Lekarz>() where u.id == dr.id select u;
            Lekarz usr = query.SingleOrDefault();

            usr.email = email;
            ctx.SubmitChanges();
        }

        public static void UpdateAdminData(Administrator admin,String name,String surname,String email,String postalCode,String city,String streetNr,Decimal? pesel,String phone,String street,String login)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();
            Repository.UpdateUserData(admin, name, surname, postalCode, city, streetNr, pesel, phone, street, login);

            var query = from u in ctx.Uzytkowniks.OfType<Administrator>() where u.id == admin.id select u;
            Administrator usr = query.SingleOrDefault();
            
            usr.email = email;
            ctx.SubmitChanges();
        }

        public static void UpdatePacjentData(Pacjent patjent, String name, String surname,  String postalCode, String city, String streetNr, Decimal? pesel, String phone, String street, String ubezpieczenie, int id_lek)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();
            Repository.UpdateUserData(patjent, name, surname, postalCode, city, streetNr, pesel, phone, street, null);

            var query = from u in ctx.Uzytkowniks.OfType<Pacjent>() where u.id == patjent.id select u;
            Pacjent usr = query.SingleOrDefault();

            usr.id_lek = id_lek;
            usr.ubezpieczenie = ubezpieczenie;
            ctx.SubmitChanges();
        }

        public static void UpdatePacjentData(Pacjent patjent)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();
            Repository.UpdateUserData(patjent, patjent.imie, patjent.nazwisko, patjent.kod_pocztowy,
                patjent.miasto, patjent.nr_domu, patjent.pesel, patjent.telefon, patjent.ulica, null);

            var query = from u in ctx.Uzytkowniks.OfType<Pacjent>() where u.id == patjent.id select u;
            Pacjent usr = query.SingleOrDefault();
            usr.ubezpieczenie = patjent.ubezpieczenie;
            usr.id_lek = patjent.id_lek;

            ctx.SubmitChanges();
        }

        public static void ChangeUserPassword(Uzytkownik user, String password)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();
            String pass = CalculateSHA1(password, Encoding.ASCII);

            var query = from u in ctx.Uzytkowniks where u.id == user.id select u;
            Uzytkownik usr = query.SingleOrDefault();

            usr.password = pass;
            ctx.SubmitChanges();
        }

        /// <summary>
        /// Funkcja dodaje specjalizacje dla podanego lekarza
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="idSpec"></param>
        public static void AddSpecjalization(Lekarz dr, int idSpec)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext();
            Specjalizacja_Lekarz sp = new Specjalizacja_Lekarz();
            sp.idSpecjalizacja = idSpec;
            sp.idUzytkownik = dr.id;
            
            //check, if dh already have those spec
            var x = from s in ctx.Specjalizacja_Lekarzs where s.idUzytkownik == dr.id && s.idSpecjalizacja == idSpec select s;

            if (x.FirstOrDefault() != null)
            {
                return;
            }

            ctx.Specjalizacja_Lekarzs.InsertOnSubmit(sp);
            ctx.SubmitChanges();
        }

        /// <summary>
        /// Funkcja usuwa wszystkie specjalizacje podanego lekarza
        /// </summary>
        /// <param name="dr"></param>
        public static void RemoveAllDrSpecjalizations(Lekarz dr)
        {
            PrzychodniaDataClassesDataContext ctx = new PrzychodniaDataClassesDataContext(); 
            var x = from sp in ctx.Specjalizacja_Lekarzs where sp.idUzytkownik == dr.id select sp;
            ctx.Specjalizacja_Lekarzs.DeleteAllOnSubmit(x.ToList());
            ctx.SubmitChanges();
        }
    }
}
