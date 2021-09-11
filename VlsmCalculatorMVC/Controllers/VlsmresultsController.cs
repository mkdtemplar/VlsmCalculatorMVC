using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VlsmDBContext;

namespace VlsmCalculatorMVC.Controllers
{
    public class VlsmresultsController : Controller
    {
        private readonly VlsmDB _context;

        public VlsmresultsController(VlsmDB context)
        {
            _context = context;
        }

        // GET: Vlsmresults
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vlsmresults.ToListAsync());
        }

        // GET: Vlsmresults/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vlsmresult = await _context.Vlsmresults
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vlsmresult == null)
            {
                return NotFound();
            }

            return View(vlsmresult);
        }

        // GET: Vlsmresults/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vlsmresults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NetworkId,Cidr,SubnetMask,NumberOfHostsPerSubnet,NumberOfSubnets,RangeOfUsableIpaddresses,BroadcastId")] Vlsmresult vlsmresult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vlsmresult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vlsmresult);
        }

        // GET: Vlsmresults/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vlsmresult = await _context.Vlsmresults.FindAsync(id);
            if (vlsmresult == null)
            {
                return NotFound();
            }
            return View(vlsmresult);
        }

        // POST: Vlsmresults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,NetworkId,Cidr,SubnetMask,NumberOfHostsPerSubnet,NumberOfSubnets,RangeOfUsableIpaddresses,BroadcastId")] Vlsmresult vlsmresult)
        {
            if (id != vlsmresult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vlsmresult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VlsmresultExists(vlsmresult.Id))
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
            return View(vlsmresult);
        }

        // GET: Vlsmresults/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vlsmresult = await _context.Vlsmresults
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vlsmresult == null)
            {
                return NotFound();
            }

            return View(vlsmresult);
        }

        // POST: Vlsmresults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var vlsmresult = await _context.Vlsmresults.FindAsync(id);
            _context.Vlsmresults.Remove(vlsmresult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VlsmresultExists(long id)
        {
            return _context.Vlsmresults.Any(e => e.Id == id);
        }
    }
}
