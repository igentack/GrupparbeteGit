using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GitGruppen.Core;
using Gitgruppen.Data;
using Gitgruppen.Models;
using System.Data;

namespace Gitgruppen.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly GitgruppenContext _context;

        public ReceiptsController(GitgruppenContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Checkout(string id)
        {

            Vehicle vehicle= _context.Vehicle.Where(e => e.LicensePlate == id).First();
            Member member = vehicle.Member;
            

            CheckoutView cov = new CheckoutView();
            cov.LicensePlate = vehicle.LicensePlate;
            cov.persnr = member.PersNr;
            cov.Arrived = vehicle.Arrived;    

            return View(cov);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutView checkoutView)
        {
            Receipt receipt = new Receipt();
            receipt.TotalCost = 0;
            receipt.Vehicle = _context.Vehicle.Where(e => e.LicensePlate == checkoutView.LicensePlate).First();
            receipt.TimeDeparture = DateTime.Now;
            _context.Add(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction($"Receipt/Details/{receipt.Id}");
        }

        // GET: Receipts
        public async Task<IActionResult> Index()
        {
            return _context.Receipt != null ?
                        View(await _context.Receipt.ToListAsync()) :
                        Problem("Entity set 'GitgruppenContext.Receipt'  is null.");
        }

        // GET: Receipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Receipt == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // GET: Receipts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeDeparture,TimeArrival,TotalCost")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Receipt == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }
            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeDeparture,TimeArrival,TotalCost")] Receipt receipt)
        {
            if (id != receipt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptExists(receipt.Id))
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
            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Receipt == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Receipt == null)
            {
                return Problem("Entity set 'GitgruppenContext.Receipt'  is null.");
            }
            var receipt = await _context.Receipt.FindAsync(id);
            if (receipt != null)
            {
                _context.Receipt.Remove(receipt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptExists(int id)
        {
            return (_context.Receipt?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
