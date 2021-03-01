using AutoMapper;
using Movie_Rater.Model;
using Movie_Rater.Model.Request;
using MovieRater.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public class KorisniciService:IKorisniciService
    {
        private readonly MovieRaterDBContext _context;
        private readonly IMapper _mapper;

        public KorisniciService(MovieRaterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public KorisniciVM Authenticiraj(string username, string pass)
        {
            var user = _context.Korisnici.FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                var hashedPass = GenerateHash(user.LozinkaSalt, pass);

                if (hashedPass == user.LozinkaHash)
                {
                    return _mapper.Map<KorisniciVM>(user);
                }
                else
                    throw new ArgumentException("Pogrešan password");
            }
            return null;
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public KorisniciVM Insert(KorisniciInsertRequest request)
        {
            var entity = _mapper.Map<Korisnici>(request);

            KorisniciVM korisnik = new KorisniciVM();

            if (request.Password != request.PasswordConfirmation)
            {
                throw new ArgumentException("Pogrešan password");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            Korisnici checkExists = _context.Korisnici.Where(w => w.KorisnickoIme == request.KorisnickoIme).FirstOrDefault();

            if (checkExists != null)
            {
                throw new ArgumentException("Korisnik već postoji");
            }

            _context.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<KorisniciVM>(entity);

        }
    }
}
