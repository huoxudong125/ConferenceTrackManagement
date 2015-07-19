using System;
using TW.CTM.Common;
using TW.CTM.Common.Extends;

namespace TW.CTM.Models
{
    public abstract class Talk
    {
        /// <summary>
        ///     The talk has two types: Normal & Lighting
        ///     The lighting talk has only default length(5 minutes). so don't need length
        ///     The normal talk you must give a length more than 1 minutes or will throw an ArgumentException.
        /// </summary>
        /// <param name="title">
        ///     the tile can't contain number, or throw an ArgumentException
        /// </param>
        /// <param name="length"> talk's length should be more than 1 and less than 180. </param>
        protected Talk(string title, int length)
        {
            Guard.ArgumentNotNullOrEmpty(title, "Title");
            if (title.IsContainNumber())
            {
                throw new ArgumentException("Title Can't contain any number!");
            }

            if (length < 1)
            {
                throw new ArgumentException("The length of normal should be more than 1 minutes!");
            }

            if (length > (60 * 3)) //TODO: the simple Scheduler can't split the talk into tow sessions.
            {
                throw new ArgumentOutOfRangeException("The length should be less than 180 minutes!");
            }

            Title = title;
            Length = length;
        }

        public string Title { get; private set; }

        /// <summary>
        ///     The talk
        ///     The unit of length is 'minute'
        /// </summary>
        public int Length { get; private set; }
    }

    public class NormalTalk : Talk
    {
        public NormalTalk(string title, int length)
            : base(title, length)
        {
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}min", Title, Length);
        }
    }

    public class LightingTalk : Talk
    {
        public LightingTalk(string title)
            : base(title, 5) // The lighting talk has only default length(5 minutes)
        {
        }

        public override string ToString()
        {
            return string.Format("{0}\t Lighting", Title);
        }
    }
}