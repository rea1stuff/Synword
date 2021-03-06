using Synword.Domain.Interfaces;

namespace Synword.Domain.Entities.SynonymDictionaryAggregate;

public class Word : BaseEntity, IAggregateRoot
{
    public string Value { get; private set; }
    public List<DictionarySynonym> Synonyms { get; private set; }
}
