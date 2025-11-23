using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;


namespace Ejemplo_HolaMundo.PageModels;

public partial class MainPageModel : ObservableObject
{
    ILogger<MainPageModel> _logger;
    readonly PersonasService _personaService;
    
    [ObservableProperty]
    private ObservableCollection<PersonaModel> personas = new();

    [ObservableProperty]
    private PersonaModel selectedItem;

    [ObservableProperty]
    private bool isBusy;
    
    [ObservableProperty]
    private string testMessage = "Inicializando...";

    private bool _personasLoaded = false;

    public MainPageModel(PersonasService personaService, ILogger<MainPageModel> logger)
    {
        this._personaService = personaService;
        this._logger = logger;
        
        TestMessage = "Constructor ejecutado";
        _logger.LogDebug("MainPageModel constructor iniciado");
        
        // Cargar personas inmediatamente
        CargarPersonas();
    }

    [RelayCommand]
    public void SelectionChanged(object param)
    {
        if (param is PersonaModel persona)
        {
            SelectedItem = persona;
            _logger.LogDebug($"Persona seleccionada: {persona.Nombre}");
        }
    }

    [RelayCommand]
    private void Appearing()
    {
        if (!_personasLoaded)
        {
            CargarPersonas();
        }
    }

    private void CargarPersonas()
    {
        if (_personasLoaded)
            return;

        try
        {
            var personas = _personaService.List();
            
            TestMessage = $"Cargadas {personas?.Count ?? 0} personas";
            _logger.LogDebug($"PersonasService retornó: {personas?.Count ?? 0} items");
            
            if (personas != null && personas.Count > 0)
            {
                Personas.Clear();
                foreach (var persona in personas)
                {
                    Personas.Add(persona);
                    _logger.LogDebug($"Agregada persona: {persona.Nombre}");
                }
                _personasLoaded = true;
                _logger.LogDebug($"Total personas cargadas: {Personas.Count}");
            }
            else
            {
                _logger.LogDebug("No se encontraron personas");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al cargar personas");
            TestMessage = $"Error: {ex.Message}";
        }
    }
}
