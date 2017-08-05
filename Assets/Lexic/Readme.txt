0. Glossary.
- Dictionary -	A class extending BasicNames and implementing its two methods.
				Those classes need to provide sets of syllables and rules 
				defining name creation. For examples, see files provided
				with this asset.

- Generator -	A "NameGen" class Component.

- Rule -		A string defining the behaviour of the name generator
				and the structure of procedurally generated names
				it will generate.

- Syllable -	Any string (even a single character) which forms a part of
				a procedurally generated name. Underscores are converted to
				spaces, otherwise all characters are permitted.

1. Basic operation.

Take a look at the demo scene to see an example of using this asset.

To keep generators using different dictionaries separate, each generator will need its
own object. To create a new generator, simply create an empty object in the hierarchy,
and drag the "NameGen" component onto it. You will need to fill the "Names Source Class"
field, which needs to contain the name of a class inheriting from BaseNames and
implementing its methods. Many such classes are provided with this asset in the
"Names" folder. Don't forget to provide the full name of the class along with its
respective namespace.

Once you have completed these two steps, you can query the generator component using
GetNextRandomName() which will return a new procedurally generated name according
to the syllables and rules of the dictionary. 

2. Defining your own dictionaries.

To create your own dictionary, simply extend the BaseNames class. You are free to 
implement its methods however you like, you are not restricted to the way stock
dictionaries do it, however two rules need to be obeyed:

- The rule list must not be empty
- Any token name used in the rule list must return a non-empty list of strings when
used as a key with GetSyllables

You can also simply use the provided template and fill its fields with your syllables and rules if
you want to keep things simple.

3. Miscellaneous

The RNG that is used to generate the names is exposed as the "rng" field of the generator.
You can replace it as long as it is a subclass of System.Random, for example if you want
to use a single RNG across the whole game so that you can reuse seeds to have reproducible
results.