# QOL Unity Attributes

> **Make your Unity Editor pretier and easily customizable without extra work with editor scripting**

**🔧 Repository is currently in active development**

A collection of **Quality-of-Life attributes for Unity** designed to improve workflow and inspector usability.  
This package focuses on conditional inspector logic such as **showing or hiding fields based on parameters**.

## ✨ Featured attributes
- [**ShowIf**](#showif): show or hide a variable based on another variable`s value
- **ReadOnly**: make a variable to be read only
- **Button**: add a button in the inspection for a specified function to be called on click

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

## 🤝 Contributing
Found a bug or have a feature request? Open an issue or submit a pull request! Contributions are welcome.

## 📃 License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
