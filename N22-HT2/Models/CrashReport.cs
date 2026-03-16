using N22_HT2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace N22_HT2.Models
{
    public class CrashReport : IReview
    {
        public Guid Id { get; set; }
        public int Star { get; set; }
        public string Message { get; set; }

        public string ScreenShot { get; set; }
        public CrashReport(int star, string message, string screenshot) => (Id, Star, Message, screenshot) = (Guid.NewGuid(), star, message, screenshot);
        public override string ToString() => $"Star(s): {Star}, Message: {Message}";
    }
}
