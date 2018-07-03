using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.Repository.Services;
using Cursos.Repository.Work;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class RefreshtokenBusiness : IRefreshtokenBusiness
    {
        public int Add(RefreshtokenViewModel entity)
        {
            //var item = m_RefreshtokenService.FindBy(x=>x.USERID == entity.Userid).FirstOrDefault();
            //if (item != null) m_RefreshtokenService.Delete(item);

            m_RefreshtokenService.Add(new Data.AD_REFRESHTOKEN
            {
                PROTECTEDTICKET = entity.Protectedticket,
                HASH = entity.Hash,
                USERID = entity.Userid,
                DTEMISSAO = DateTime.Now,
                DTEMISSAOUTC = entity.Dtemissaoutc,
                DTEXPIRACAO = entity.Dtexpiracao,
                DTEXPIRACAOUTC = entity.Dtexpiracaoutc,
            });
            return m_RefreshtokenService.Commit();
        }

        public int Delete(RefreshtokenViewModel entity)
        {
            var item = m_RefreshtokenService.GetById(entity.Id);
            if (item != null)
            {
                m_RefreshtokenService.Delete(item);
            }
            return m_RefreshtokenService.Commit();
        }

        public IEnumerable<RefreshtokenViewModel> GetAll()
        {
            return m_RefreshtokenService.GetAll().Select(item => new RefreshtokenViewModel {
                Id = item.ID,
                Dtemissao = item.DTEMISSAO,
                Hash = item.HASH,
                Protectedticket = item.PROTECTEDTICKET,
                Userid = item.USERID,
            });
        }

        public RefreshtokenViewModel GetById(int id)
        {
            var item = m_RefreshtokenService.GetById(id);
            if (item == null) return null;

            return new RefreshtokenViewModel
            {
                Id = item.ID,
                Dtemissao = item.DTEMISSAO,
                Hash = item.HASH,
                Protectedticket = item.PROTECTEDTICKET,
                Userid = item.USERID,
            };
        }

        public int Update(RefreshtokenViewModel entity)
        {
            var item = m_RefreshtokenService.GetById(entity.Id);
            if (item != null) return 0;

            item.PROTECTEDTICKET = entity.Protectedticket;
            item.HASH = entity.Hash;
            m_RefreshtokenService.Update(item);

            return m_RefreshtokenService.Commit();
        }
    }
}
