namespace TanjiMimic.Utilities.Enums
{
    /// <summary>
    /// Returns a TanjiMimic Response
    /// </summary>
    public enum TSpeech
    {
        /// <summary>
        /// Represents A Blank Response
        /// </summary>
        Say = 0,
        /// <summary>
        /// Represents A Successful Outcome
        /// </summary>
        Shout = 1,
        /// <summary>
        /// Represents A Failed Outcome
        /// </summary>
        Whisper = 2,
        /// <summary>
        /// That Item already Exists
        /// </summary>    
        None = 3
        /// <summary>
        /// Represents An Error
        /// </summary>  
    }
}