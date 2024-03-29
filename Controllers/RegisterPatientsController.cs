﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pathology.Models;
using Pathology.Services;
using Pathology.ViewModels;

namespace Pathology.Controllers
{
    [Authorize]
    public class RegisterPatientsController : Controller
    {
        private readonly AppDBcontext _context;
        private readonly UserManager<User> userManager;
        private readonly IUserService _userService;
        private readonly ILogger<RegisterPatientsController> logger;

        public RegisterPatientsController(AppDBcontext context,
                                            UserManager<User> userManager,
                                            IUserService userService,
                                            ILogger<RegisterPatientsController> logger)
        {
            _context = context;
            this.userManager = userManager;
            this._userService = userService;
            this.logger = logger;
        }

        // GET: RegisterPatients
        public async Task<IActionResult> Index()
        {
            var appDBcontext = _context.RegisterPatient.Include(r => r.Package).Include(r => r.Patient).Include(r => r.TestMgmt).Include(r => r.User);
            return View(await appDBcontext.ToListAsync());
        }

        // GET: RegisterPatients/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerPatient = await _context.RegisterPatient
                .Include(r => r.Package)
                .Include(r => r.Patient)
                .Include(r => r.TestMgmt)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RegisterID == id);
            if (registerPatient == null)
            {
                return NotFound();
            }

            return View(registerPatient);
        }

        // GET: RegisterPatients/Create
        public IActionResult Create()
        {
            var users = userManager.Users;
            var Id = _userService.GetUserID();

            ViewData["PackageID"] = new SelectList(_context.Packages, "PackageID", "PackageName");
            ViewData["PackagrPrice"] = new SelectList(_context.Packages, "PackageID", "PackagrPrice");
            ViewData["TestId"] = new SelectList(_context.TestMgmt, "TestId", "TestName");
            ViewData["TestPrice"] = new SelectList(_context.TestMgmt, "TestId", "TestPrice");
            ViewData["Id"] = Id;

            return View();
        }

        // POST: RegisterPatients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegisterID,PatientID,TestId,PackageID,RegDateTime,TotalAmount,Id")] RegisterPatient registerPatient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerPatient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PackageID"] = new SelectList(_context.Packages, "PackageID", "PackageName", registerPatient.PackageID);
            ViewData["TestId"] = new SelectList(_context.TestMgmt, "TestId", "TestName", registerPatient.TestId);

            var users = userManager.Users;
            var Id = _userService.GetUserID();
            ViewData["Id"] = Id;

            return View(registerPatient);
        }

        // GET: RegisterPatients/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerPatient = await _context.RegisterPatient.FindAsync(id);
            if (registerPatient == null)
            {
                return NotFound();
            }
            ViewData["PackageID"] = new SelectList(_context.Packages, "PackageID", "PackageName", registerPatient.PackageID);
            ViewData["PatientID"] = new SelectList(_context.Patient, "PatientID", "PatientID", registerPatient.PatientID);
            ViewData["TestId"] = new SelectList(_context.TestMgmt, "TestId", "TestName", registerPatient.TestId);
            var Id = _userService.GetUserID();
            ViewData["Id"] = Id;
            return View(registerPatient);
        }

        // POST: RegisterPatients/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, [Bind("RegisterID,PatientID,TestId,PackageID,RegDateTime,TotalAmount,Id,IsReportGenerated,RoportPDF")] RegisterPatient registerPatient)
        {
            if (id != registerPatient.RegisterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerPatient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterPatientExists(registerPatient.RegisterID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PackageID"] = new SelectList(_context.Packages, "PackageID", "PackageDescription", registerPatient.PackageID);
            ViewData["PatientID"] = new SelectList(_context.Patient, "PatientID", "PatientAadharID", registerPatient.PatientID);
            ViewData["TestId"] = new SelectList(_context.TestMgmt, "TestId", "TestName", registerPatient.TestId);

            var Id = _userService.GetUserID();
            ViewData["Id"] = Id;
            return View(registerPatient);
        }

        // GET: RegisterPatients/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerPatient = await _context.RegisterPatient
                .Include(r => r.Package)
                .Include(r => r.Patient)
                .Include(r => r.TestMgmt)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RegisterID == id);
            if (registerPatient == null)
            {
                return NotFound();
            }

            return View(registerPatient);
        }

        // POST: RegisterPatients/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registerPatient = await _context.RegisterPatient.FindAsync(id);
            _context.RegisterPatient.Remove(registerPatient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterPatientExists(int id)
        {
            return _context.RegisterPatient.Any(e => e.RegisterID == id);
        }

        public IActionResult GetPricePackage(int packageid)
        {
            var packagrPrice = _context.Packages.Where(c => c.PackageID == packageid)
                                       .Select(c => c.PackagrPrice);
            return Json(packagrPrice);
        }

        public IActionResult GetPriceTest(int testid)
        {
            var testPrice = _context.TestMgmt.Where(c => c.TestId == testid)
                                       .Select(c => c.TestPrice);
            return Json(testPrice);
        }

        public IActionResult FileUpload(int Id)
        {
            ViewData["Id"] = Id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadPdf(int? id, IFormFile file)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regPatient = await _context.RegisterPatient.FindAsync(id);
            if (regPatient == null)
            {
                return NotFound();
            }

            if (file != null)
            {
                if (file.Length > 0 && file.Length < 300000)
                {
                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        regPatient.RoportPDF = target.ToArray();
                    }
                    regPatient.IsReportGenerated = true;
                    _context.RegisterPatient.Update(regPatient);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("SendEmail", new { RegistrationId = id });
                }

                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> DownloadPdf(int? Id)
        {
            var regPatient = await _context.RegisterPatient.FirstOrDefaultAsync(x => x.RegisterID == Id);

            if (regPatient == null)
            {
                return NotFound();
            }
            if (regPatient.RoportPDF == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                byte[] myFile = regPatient.RoportPDF;
                string filetype = "Application/pdf";

                return new FileContentResult(myFile, filetype);
            }
        }

        public IActionResult FileDelete(int Id)
        {
            ViewData["Id"] = Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePdf(int? Id)
        {
            var regPatient = await _context.RegisterPatient.FirstOrDefaultAsync(x => x.RegisterID == Id);

            if (regPatient == null)
            {
                return NotFound();
            }
            if (regPatient.RoportPDF == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                regPatient.RoportPDF = null;
                regPatient.IsReportGenerated = false;
                _context.RegisterPatient.Update(regPatient);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
        }

        //called by UploadPDF
        public IActionResult SendEmail(int RegistrationId)
        {
            var registerPatient = _context.RegisterPatient.FirstOrDefault(y => y.RegisterID == RegistrationId);

            var patient = _context.Patient.FirstOrDefault(x => x.PatientID == registerPatient.PatientID);

            var email = patient.PatientEmail;

            MailMessage mm = new MailMessage();

            mm.Subject = "Report Generated";
            mm.Body = "Your report has been generated";
            mm.From = new MailAddress("icarediagnostics88@gmail.com");
            mm.To.Add(new MailAddress(email));
            mm.IsBodyHtml = false;

            if (registerPatient.IsPaymentDone && registerPatient.IsReportGenerated)
            {
                MemoryStream myFile = new MemoryStream(registerPatient.RoportPDF);
                string filetype = "Report.pdf";
                mm.Attachments.Add(new Attachment(myFile, filetype));
            }

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("icarediagnostics88@gmail.com", "uqvxrnivqpgannoj");
                //smtp.UseDefaultCredentials = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                ViewBag.Message = "Email sent";
            }
            return RedirectToAction("Index");
        }

        //RegisterPatientSearch
        public async Task<IActionResult> RegPatientSearch(DateTime SearchTerm)
        {
            if (SearchTerm.Year > 1)
            {
                var regPatients = from p in _context.RegisterPatient.Include(r => r.Package).Include(r => r.Patient).Include(r => r.TestMgmt).Include(r => r.User)
                                  select p;

                regPatients = regPatients.Where(s => s.RegDateTime.Date == SearchTerm);

                return View(await regPatients.ToListAsync());
            }

            return View();
        }

        //StoredProcedure
        public IActionResult GetRPStats(DateTime dateTime1, DateTime dateTime2, int selection)
        {
            StatisticsVM statisticsVM = new StatisticsVM();

            if (dateTime1.Year > 1 && dateTime2.Year > 1)
            {
                ViewData["DateTime1"] = dateTime1.ToString("yyyy-MM-dd");
                ViewData["DateTime2"] = dateTime2.ToString("yyyy-MM-dd");
                ViewBag.Selection = selection;

                if (selection == 1)
                {
                    //var RegPatient = _context.RegisterPatient
                    //.FromSqlRaw("spRegPatFKs {0}, {1}", dateTime1, dateTime2);

                    var regPatients = from p in _context.RegisterPatient.Include(r => r.Package).Include(r => r.Patient).Include(r => r.TestMgmt).Include(r => r.User)
                                      select p;
                    regPatients = regPatients.Where(s => s.RegDateTime.Date > dateTime1 && s.RegDateTime < dateTime2);

                    statisticsVM.RegisterPatients = regPatients;
                    int count = 0;
                    foreach (var item in regPatients)
                    {
                        count++;
                    }
                    ViewBag.count = count;

                    return View(statisticsVM);
                }
                else if (selection == 2)
                {
                    var payment = _context.Payment
                    .FromSqlRaw<Payment>("spGetStats {0}, {1}, {2}", dateTime1, dateTime2, selection);

                    statisticsVM.Payments = payment;
                    int lastAmount = 0;
                    int lastTotalAmount = 0;
                    int lastNetAmount = 0;
                    int count = 0;
                    foreach (var item in payment)
                    {
                        lastAmount += item.Amount;
                        lastTotalAmount += item.TotalAmount;
                        lastNetAmount += item.NetAmount;
                        count++;
                    }
                    ViewBag.lastAmount = lastAmount;
                    ViewBag.lastTotalAmount = lastTotalAmount;
                    ViewBag.lastNetAmount = lastNetAmount;
                    ViewBag.count = count;

                    return View(statisticsVM);
                }
                else if (selection == 3)
                {
                    var patient = _context.Patient
                    .FromSqlRaw<Patient>("spGetStats {0}, {1}, {2}", dateTime1, dateTime2, selection);

                    statisticsVM.Patients = patient;
                    int count = 0;
                    foreach (var item in patient)
                    {
                        count++;
                    }
                    ViewBag.count = count;

                    return View(statisticsVM);
                }

                else if (selection == 4)
                {
                    var regPatients = _context.RegisterPatient.Include(r => r.Package).Include(r => r.Patient)
                                      .Include(r => r.TestMgmt).Include(r => r.User)
                                      .Where(s => s.RegDateTime.Date > dateTime1 && s.RegDateTime < dateTime2);

                    statisticsVM.RegisterPatients = regPatients;

                    var results = regPatients.ToList().GroupBy(
                                      p => p.TestId,
                                      p => p.RegisterID,
                                      (key, g) => new { TestId = key, Tests = g.ToList() });

                    List<Other> tempList = new();

                    foreach (var item in results)
                    {
                        var testN = _context.TestMgmt.Where(s => s.TestId == item.TestId).Select(c => c.TestName).FirstOrDefault();
                        
                        tempList.Add(
                                    new Other() { Otherlist = item.Tests, Key = testN, Count = item.Tests.Count() }
                                    );
                    }

                    //var other = _context.RegisterPatient.AsEnumerable().GroupBy(TestId => TestId)
                    //             .Select(g => new Other() { Key = g.Key, Count = g.Count() });

                    var other1 = _context.RegisterPatient
                    .FromSqlRaw("spGetminmax {0}, {1}, {2}", dateTime1, dateTime2, selection);

                    statisticsVM.Others = tempList;

                    return View(statisticsVM);
                }

                else if (selection == 5)
                {
                    var regPatients = _context.RegisterPatient.Include(r => r.Package).Include(r => r.Patient)
                                      .Include(r => r.TestMgmt).Include(r => r.User)
                                      .Where(s => s.RegDateTime.Date > dateTime1 && s.RegDateTime < dateTime2);

                    statisticsVM.RegisterPatients = regPatients;

                    var results = regPatients.ToList().GroupBy(
                                      p => p.PackageID,
                                      p => p.RegisterID,
                                      (key, g) => new { PackageID = key, Packages = g.ToList() });

                    List<Other> tempList = new();

                    foreach (var item in results)
                    {
                        var packageN = _context.Packages.Where(s => s.PackageID == item.PackageID).Select(c => c.PackageName).FirstOrDefault();

                        tempList.Add(
                                    new Other() { Otherlist = item.Packages, Key = packageN, Count = item.Packages.Count() }
                                    );
                    }

                    //var other = _context.RegisterPatient.AsEnumerable().GroupBy(TestId => TestId)
                    //             .Select(g => new Other() { Key = g.Key, Count = g.Count() });

                    var other1 = _context.RegisterPatient
                    .FromSqlRaw("spGetminmax {0}, {1}, {2}", dateTime1, dateTime2, selection);

                    statisticsVM.Others = tempList;

                    return View(statisticsVM);
                }
            }

            return View(statisticsVM);
        }
    }
}
