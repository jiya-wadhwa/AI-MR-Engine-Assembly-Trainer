using System.Collections.Generic;
using UnityEngine;

public class AssemblyManager : MonoBehaviour
{
    public static AssemblyManager Instance;

    public List<AssemblyStep> steps = new();

    private int currentStepIndex = 0;

    public AssemblyStep CurrentStep => steps[currentStepIndex];

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        InitializeSteps();
        ShowCurrentStep();
    }

    void InitializeSteps()
    {
        steps.Clear();

        steps.Add(new AssemblyStep
        {
            stepNumber = 1,
            title = "Install Crankshaft",
            description = "Move the crankshaft into its position.",
            requiredPart = PartType.Crankshaft
        });

        steps.Add(new AssemblyStep
        {
            stepNumber = 2,
            title = "Install Connecting Rod",
            description = "Install the first connecting rod.",
            requiredPart = PartType.ConnectingRod
        });

        steps.Add(new AssemblyStep
        {
            stepNumber = 3,
            title = "Install Piston",
            description = "Install the first piston.",
            requiredPart = PartType.Piston
        });

        steps.Add(new AssemblyStep
        {
            stepNumber = 4,
            title = "Install Camshaft",
            description = "Place the camshaft correctly.",
            requiredPart = PartType.Camshaft
        });

        steps.Add(new AssemblyStep
        {
            stepNumber = 5,
            title = "Install Timing Belt",
            description = "Fit the timing belt.",
            requiredPart = PartType.TimingBelt
        });

        steps.Add(new AssemblyStep
        {
            stepNumber = 6,
            title = "Assembly Complete",
            description = "Engine assembled successfully.",
            requiredPart = PartType.None
        });
    }

    void ShowCurrentStep()
    {
        if (InstructionOverlay.Instance == null)
            return;

        InstructionOverlay.Instance.ShowInstruction(
            CurrentStep.stepNumber,
            CurrentStep.title,
            CurrentStep.description
        );
    }

    public PartType GetRequiredPart()
    {
        return CurrentStep.requiredPart;
    }

    public void CompleteCurrentStep()
    {
        if (InstructionOverlay.Instance != null)
        {
            InstructionOverlay.Instance.ShowSuccess(
                CurrentStep.title + " Installed"
            );
        }

        Invoke(nameof(LoadNextStep), 1.2f);
    }

    void LoadNextStep()
    {
        currentStepIndex++;

        if (currentStepIndex >= steps.Count)
            return;

        ShowCurrentStep();
    }
}