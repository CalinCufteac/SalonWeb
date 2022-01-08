using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonWeb.Data;

namespace SalonWeb.Models
{
    public class ProgramareTipsPageModel:PageModel
    {
        public List<AssignedTipData> AssignedTipDataList;

        public void PopulateAssignedTipData(SalonWebContext context,Programare programare)
        {
            var allTips = context.Tip;
            var programareTips = new HashSet<int>(
            programare.ProgramareTips.Select(c => c.TipID)); //
            AssignedTipDataList = new List<AssignedTipData>();
            foreach (var cat in allTips)
            {
                AssignedTipDataList.Add(new AssignedTipData
                {
                    TipID = cat.ID,
                    Nume = cat.TipTuns,
                    Assigned = programareTips.Contains(cat.ID)
                });
            }
        }
        public void UpdateProgramareTips(SalonWebContext context,
                string[] selectedTips, Programare programareToUpdate)
        {
            if (selectedTips == null)
            {
                programareToUpdate.ProgramareTips = new List<ProgramareTip>();
                return;
            }
            var selectedTipsHS = new HashSet<string>(selectedTips);
            var programareTips = new HashSet<int>
            (programareToUpdate.ProgramareTips.Select(c => c.Tip.ID));
            foreach (var cat in context.Tip)

                if (selectedTipsHS.Contains(cat.ID.ToString()))
                {
                    if (!programareTips.Contains(cat.ID))
                    {
                        programareToUpdate.ProgramareTips.Add(
                        new ProgramareTip
                        {
                            ProgramareID = programareToUpdate.ID,
                            TipID = cat.ID
                        });
                    }
                }
                else
                {
                    if (programareTips.Contains(cat.ID))
                    {
                        ProgramareTip courseToRemove
                        = programareToUpdate
                        .ProgramareTips
                       .SingleOrDefault(i => i.TipID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
           }

    }
