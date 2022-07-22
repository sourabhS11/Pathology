using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Html2pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pathology.Models;

namespace Pathology.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly AppDBcontext _context;

        public PaymentsController(AppDBcontext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var appDBcontext = _context.Payment;
            return View(await appDBcontext.ToListAsync());
        }

        // GET: Payments/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment.FirstOrDefaultAsync(m => m.PaymentID == id);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create(int Id, string PatientName, string TestName, string PackageName)
        {
            ViewData["RegisterID"] = Id;
            ViewData["PatientName"] = PatientName;
            ViewData["TestName"] = TestName;
            ViewData["PackageName"] = PackageName;

            return View();
        }

        // POST: Payments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentID,PaymentDate,RegisterID,ModeOfPayment,TransactionID,Amount,GST,TotalAmount,DiscountAllowed,NetAmount")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();

                return View(payment);
            }
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["RegisterID"] = new SelectList(_context.Patient, "PatientID", "PatientAadharID", payment.RegisterID);
            return View(payment);
        }

        // POST: Payments/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentID,PaymentDate,RegisterID,ModeOfPayment,TransactionID,Amount,GST,TotalAmount,DiscountAllowed,NetAmount")] Payment payment)
        {
            if (id != payment.PaymentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentID))
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
            ViewData["RegisterID"] = new SelectList(_context.Patient, "PatientID", "PatientAadharID", payment.RegisterID);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment.FirstOrDefaultAsync(m => m.PaymentID == id);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payment.Any(e => e.PaymentID == id);
        }

        public IActionResult GetAmount(int id)
        {
            var amount = _context.RegisterPatient.Where(c => c.RegisterID == id)
                                       .Select(c => c.TotalAmount);
            return Json(amount);
        }

        public IActionResult GenerateReceiptPdf(Payment payment)
        {
            var patientName = payment.PatientName;
            var testName = payment.TestName;
            var packageName = payment.PackageName;

            var paymentDate = payment.PaymentDate;
            var amouunt = payment.Amount;
            var gst = payment.GST;
            var totalAmount = payment.TotalAmount;
            var discountAllowed = payment.DiscountAllowed;
            var netAmount = payment.NetAmount;
            var modeOfPayment = payment.ModeOfPayment;

            var content = System.IO.File.ReadAllText("Templates/ReceiptHTMLTemplate.html");
            content = content.Replace("PAYMENTDATE", paymentDate.ToString());
            content = content.Replace("PATIENTNAME", patientName);
            content = content.Replace("PACKAGENAME", packageName);
            content = content.Replace("TESTNAME", testName);
            content = content.Replace("TOTALAMOUNT", totalAmount.ToString());
            content = content.Replace("GST", gst.ToString());
            content = content.Replace("DISCOUNTALLOWED", discountAllowed.ToString());
            content = content.Replace("NETAMOUNT", netAmount.ToString());
            content = content.Replace("ModeOfPayment", modeOfPayment);
            content = content.Replace("AMOUNT", amouunt.ToString());

            using (MemoryStream stream = new MemoryStream())
            {
                HtmlConverter.ConvertToPdf(content, stream);
                return File(stream.ToArray(), "application/pdf", "Receipt.pdf");
            }
        }
    }
}
