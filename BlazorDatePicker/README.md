# Blazor Localized Date Picker Example
An example of using Blazor JS interop and localization for a date picker.

This Blazor component uses **flatpickr** datetime picker and shows how it can be used
in Blazor applications.

Localization was simplified in this example. In an actual Blazor project, it could use .Net
CultureInfo combined with cookies or other mechanisms (such as data from a database) to
set any of the [flatpickr supported languages](https://github.com/flatpickr/flatpickr/tree/master/src/l10n).

### This example shows
- Blazor JavaScript interoperability ([JS interop](https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/)) 
- Simple localization for the **flatpickr** object.
- How to dynamically load a script with jQuery.
- Blazor component creation and how to pass parameters.
- How to communicate a Blazor component with a parent object (a page, in this case).

## Setup
We need the [flatpickr](https://flatpickr.js.org/getting-started/) scripts. In this case we'll use the CDN resources.

In your Blazor project:

- Add the *flatpickr-date-picker.js* file to the *wwwroot* folder.

- Include the *Flatpickr.razor* component file in other folder of your project.

- In the *index.html* page add the references for **flatpick** and the *flatpickr-date-picker.js* file. This JavaScript example uses jQuery, so you may need to add it if you don't have it already.
```
    <script src="https://code.jquery.com/jquery-3.6.3.min.js" integrity="sha256-pvPw+upLPUjgMXY0G+8O0xUf+/Im1MZjXxxgOcBQBXU=" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/flatpickr"></script>
    <script src="flatpickr-date-picker.js"></script>
```


## Usage
In your razor component:
```
<Flatpickr />
```
Within the parameters, *OnChange* will wrap the component event to capture the date selected.
E.g.:
```
<Flatpickr OnChange="DateChanged" />

@code{
    Task DateChanged(DateTime newDate)
    {
       // do something 
       // ...

        return Task.CompletedTask;
    }
}
```

## Finally
People who made and do maintain flatpickr did great work to help us make our development easier.
Please give a Star to the developer: https://github.com/flatpickr/flatpickr
