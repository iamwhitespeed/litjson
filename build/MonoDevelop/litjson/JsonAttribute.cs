using System;
using System.Collections.Generic;

namespace LitJson
{

[Flags]
public enum JsonIgnoreWhen {
	Never = 0,
	Serializing = 1,
	Deserializing = 2
}

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class JsonIgnore : Attribute {
	public JsonIgnoreWhen Usage { get; private set; }

	public JsonIgnore() {
		Usage = JsonIgnoreWhen.Serializing | JsonIgnoreWhen.Deserializing;
	}

	public JsonIgnore(JsonIgnoreWhen usage) {
		Usage = usage;
	}
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
public class JsonIgnoreMember : Attribute {
	public HashSet<string> Members { get; private set; }

	public JsonIgnoreMember(params string[] members) : this((ICollection<string>)members) {
	}

	public JsonIgnoreMember(ICollection<string> members) {
		Members = new HashSet<string>(members);
	}
}


[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class JsonAlias : Attribute {
	public string Alias { get; private set; }
	public bool AcceptOriginal { get; private set; }

	public JsonAlias(string aliasName, bool acceptOriginalName = false) {
		Alias = aliasName;
		AcceptOriginal = acceptOriginalName;
	}
}

}
