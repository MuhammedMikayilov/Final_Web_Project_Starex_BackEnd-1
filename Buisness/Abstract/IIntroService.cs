using Entity.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
    public interface IIntroService
    {
        Intro GetIntroWithId(int id);
        List<Intro> GetAllIntro();
        void AddIntro(Intro data);
        void UpdateIntro(Intro data);
        void Delete(int id);
    }
}
