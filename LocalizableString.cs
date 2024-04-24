using System.Collections.ObjectModel;

namespace Test
{
    public sealed class LocalizableString : ReadOnlyDictionary<string, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizableString"/> class.
        /// </summary>
        public LocalizableString()
            : base(new Dictionary<string, string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizableString"/> class from the specified dictionary.
        /// </summary>
        /// <param name="dictionary">The dictionary that contains the data to copy.</param>
        public LocalizableString(IDictionary<string, string> dictionary)
            : base(dictionary)
        {
        }

        /// <summary>
        /// Gets the extended properties used with OData query.
        /// </summary>
        public IDictionary<string, object> ExtendedProperties
        {
            get
            {
                return this.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
            }
        }

        /// <summary>
        /// Gets the translation for the specified language.
        /// </summary>
        /// <param name="key">The language id.</param>
        /// <returns>The translation.</returns>
        /// <exception cref="KeyNotFoundException">The language id does not exist.</exception>"
        public new string this[string key]
        {
            get { return base[key]; }
        }
    }
}