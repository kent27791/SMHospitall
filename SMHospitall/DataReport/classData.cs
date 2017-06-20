using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using SMHospitall.Data;
using SMHospitall.DataReport;
namespace SMHospitall
{
    public static class classData
    {
        //Báo cáo tổng hợp cấp giấy nghỉ ốm
        public static List<reportSicks> GetDataReportSicks(this UnitOfWork work, DateTime from, DateTime to)
        {
            var title = String.Format("Từ ngày: {0:dd/MM/yyyy} đến ngày: {1:dd/MM/yyyy}", from, to);
            var sick = work.Query<Data.OffWork>()
                           .Where(p => p.DateTime <= to && p.DateTime >= from && p.Sick != null)
                           .Select(p => new reportSicks
                           {
                               Title = title,
                               offwork = p
                           }).ToList();
            return sick;
        }
        //Báo cáo nghỉ ốm theo khoa - bác sỹ
        public static List<reportSicksByDoctor> GetDataReportSickByDoctors(this UnitOfWork work,int sickid, DateTime from, DateTime to)
        {
            var title = String.Format("Từ ngày: {0:dd/MM/yyyy} đến ngày: {1:dd/MM/yyyy}", from, to);
            var ids = work.Query<Data.Official>().FirstOrDefault(p => p.Id == sickid);
            var si = ids.OffWorks.Where(p => p.DateTime <= to && p.DateTime >= from && p.Sick != null);
            return si.Select(p => new reportSicksByDoctor
            {
               Title = title,
               offwork=p
            }).ToList();
        }
        //Báo cáo nghỉ ốm theo bệnh nhân
        //public static reportSicksBySicks GetDataReportSickBySicks(this UnitOfWork work, DateTime from, DateTime to)
        //{
        //    var title = String.Format("Từ ngày: {0:dd/MM/yyyy} đến ngày: {1:dd/MM/yyyy}", from, to);
        //    var sickbysicks = work.Query<Data.OffWork>()
        //                           .Where(p => p.DateTime <= to && p.DateTime >= from && p.Sick != null);
        //    return new reportSicksBySicks()
        //    {
        //        offwork = sickbysicks.ToList(),
        //        Title = title
        //    };
        //}
        //Báo cáo nghỉ ốm theo bệnh nhân
        public static List<reportSicksBySicks> GetDataReportSickBySicks(this UnitOfWork work, int oid, DateTime from, DateTime to)
        {
            var title = String.Format("Từ ngày: {0:dd/MM/yyyy} đến ngày: {1:dd/MM/yyyy}", from, to);
            var oids = work.Query<Data.Sick>().FirstOrDefault(p => p.Id == oid);
            var si = oids.OffWorks.Where(p => p.DateTime <= to && p.DateTime >= from && p.Official != null);
            return si.Select(p => new reportSicksBySicks
            {
                Title = title,
                offwork = p
            }).ToList();
        }
        //Báo cáo chuyển viện tổng hợp
        public static List<dataToHospitall> GetDataReportToHospitall(this UnitOfWork work, DateTime from, DateTime to)
        {
            var title = String.Format("Từ ngày: {0:dd/MM/yyyy} đến ngày: {1:dd/MM/yyyy}", from, to);
            var hospitall = work.Query<Data.ToHospitall>()
                         .Where(p => p.DateTime <= to && p.DateTime >= from && p.Sick != null)
                           .Select(p => new dataToHospitall
                           {
                               Title = title,
                               tohospitall = p
                           }).ToList();
            return hospitall;
        }
        //Báo cáo chuyển viện theo khoa - bác sỹ
        public static List<dataToHospitallByDoctor> GetdataToHospitallByDoctor(this UnitOfWork work, int sickid, DateTime from, DateTime to)
        {
            var title = String.Format("Từ ngày: {0:dd/MM/yyyy} đến ngày: {1:dd/MM/yyyy}", from, to);
            var ids = work.Query<Data.Official>().FirstOrDefault(p => p.Id == sickid);
            var si = ids.ToHospitalls.Where(p => p.DateTime <= to && p.DateTime >= from && p.Sick != null);
            return si.Select(p => new dataToHospitallByDoctor
            {
                Title = title,
                tohospitall = p
            }).ToList();
        }
        //Báo cáo chuyển viện theo bệnh nhân
        public static List<dataToHospitalBySicks> GetDataToHospitalBySicks(this UnitOfWork work, int oid, DateTime from, DateTime to)
        {
            var title = String.Format("Từ ngày: {0:dd/MM/yyyy} đến ngày: {1:dd/MM/yyyy}", from, to);
            var oids = work.Query<Data.Sick>().FirstOrDefault(p => p.Id == oid);
            var si = oids.ToHospitalls.Where(p => p.DateTime <= to && p.DateTime >= from && p.Official != null);
            return si.Select(p => new dataToHospitalBySicks
            {
                Title = title,
                tohospital = p
            }).ToList();
        }
    }
}
