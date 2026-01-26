# QOL Unity Attributes

> **Make your Unity Editor pretier and easily customizable without extra work with editor scripting**

**🔧 Repository is currently in active development**

A collection of **Quality-of-Life attributes for Unity** designed to improve workflow and inspector usability.  
This package focuses on conditional inspector logic such as **showing or hiding fields based on parameters**.

## ✨ Featured attributes
- [**ShowIf**](#showif): show or hide a variable based on another variable`s value
- [**ReadOnly**](#readonly): make a variable to be read only
- [**Button**](#button): add a button in the inspection for a specified function to be called on click

## 📦 Installation
### Option 1: Unity Package Manager (Git URL)

1. Open **Unity**
2. Go to Window → Package Manager
3. Click the + button
4. Select Add package from git URL
5. Paste:
```

https://github.com/EnjoyW0rld/QOL-Unity-Attributes.git

```

### Option 2: Direct download
You can [download directly](https://github.com/EnjoyW0rld/QOL-Unity-Attributes/releases) a *.unitypackage* file and simply drag and drop it into your project

## 📖 Documentation
### ShowIf
![Show if attribute showcase gif](https://github.com/EnjoyW0rld/QOL-Unity-Attributes/blob/DocsUpd/docs/images/ShowIf.gif)

Show if the attrbute has two constructors -

**First constructor `public ShowIfAttribute(string pValueToCompare, ComparisonType pComparer = ComparisonType.IsNotNull)`**  
For the cases when it is needed to check if the target value is null or not, the comparison type can be omitted in most of the cases.  
> **string pValueToCompare** - pass a name with of the target variable you want to be compared

**Second constructor `public ShowIfAttribute(string pValueToCompare, ComparisonType pComparer, object pTargetValue)`**  
This is a general constructor that includes all the cases possible in the current version of the ShowIf attribute.  
> **object pTargetValue** - value that variable will be compared with (for example 1, 2.5, true, false, etc.).

Choosing which comparison type to use is made through the enum list -
```
enum ComparisonType
        {
            Less,
            Equal,
            NotEqual,
            Bigger,
            IsNull,
            IsNotNull
        }
```
#### ⚠️Known problems
- ShowIf attribute can not compare the size of the array to the desired length
- Can not fully customize the comparison mechanism (for example, show variable if the comparable variable is >3 and <10)

### ReadOnly
Simply add the `ReadOnly` attribute to the variable, and you are good to go. Attribute should work with the most default and some Unity-specific variables.

### Button
The button attribute allows you to include in the script editor window buttons to call specified functions.  
Add to a variable `[Button(..)]` attribute to make the editor draw a button. The class comes with two constructors, where main is - 

> public ButtonAttribute(string pTargetFunction, string pDisplayName, bool pDoDrawUnder = false)

- Where pTargetFunction is the name of the function to be called (the function needs to be without parameters).  
- pDisplay name is the text to be written on the button itself; this parameter can be omitted if you don`t need custom text on the button.  
- pDoDrawUnder is a bool determining if the button will be drawn on top (by default) of the variable this attribute is attached to or under.

## 🤝 Contributing
Found a bug or have a feature request? Open an issue or submit a pull request! Contributions are welcome.

## 📃 License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
