using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Logs;

namespace DataAccess.Repositories.Linq
{
    public class TaProceduceTypeRepository : TaDataContextEntity<ProceduceType>, ITaProceduceTypeRepository
    {

        public int GetReceiptProceduceType()
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    return Context.ProceduceTypes.Where(x => x.Code == EProceduceType.R.ToString()).FirstOrDefault().Id;
                }
                catch (Exception ex)
                {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }
                finally
                {
                    Context.Dispose();
                }
                return 0;
            }
        }
    }
}
