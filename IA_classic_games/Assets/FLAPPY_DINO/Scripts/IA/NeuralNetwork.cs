using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetwork : MonoBehaviour
{
    [SerializeField] private int inputSize;
    [SerializeField] private int outputSize;
    [SerializeField] private int[] layerSizes;
    [SerializeField] private float learningRate;
    [SerializeField] public double[][] weights;
    [SerializeField] public double[][] biases;

     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public NeuralNetwork(int inputSize, int outputSize, int[] layerSizes, float learningRate)
    {
        this.inputSize = inputSize;
        this.outputSize = outputSize;
        this.layerSizes = layerSizes;
        this.learningRate = learningRate;

        InitializeWeightsAndBiases();
    }

    private void InitializeWeightsAndBiases()
    {
        int totalLayers = layerSizes.Length + 1;
        weights = new double[totalLayers][];
        biases = new double[totalLayers][];

        int previousLayerSize = inputSize;

        for (int i = 0; i < layerSizes.Length; i++)
        {
            int currentLayerSize = layerSizes[i];

            weights[i] = new double[currentLayerSize * previousLayerSize];
            biases[i] = new double[currentLayerSize];

            // Inicialização dos pesos e bias com valores aleatórios
            for (int j = 0; j < currentLayerSize * previousLayerSize; j++)
            {
                weights[i][j] = UnityEngine.Random.Range(-1f, 1f);
            }

            for (int j = 0; j < currentLayerSize; j++)
            {
                biases[i][j] = UnityEngine.Random.Range(-1f, 1f);
            }

            previousLayerSize = currentLayerSize;
        }

        // Última camada para output
        weights[totalLayers - 1] = new double[outputSize * previousLayerSize];
        biases[totalLayers - 1] = new double[outputSize];

        // Inicialização dos pesos e bias com valores aleatórios para a camada de output
        for (int j = 0; j < outputSize * previousLayerSize; j++)
        {
            weights[totalLayers - 1][j] = UnityEngine.Random.Range(-1f, 1f);
        }

        for (int j = 0; j < outputSize; j++)
        {
            biases[totalLayers - 1][j] = UnityEngine.Random.Range(-1f, 1f);
        }
    }

    private double Sigmoid(double x)
    {
        return 1.0 / (1.0 + Mathf.Exp((float)-x));
    }

    public void Train()
    {
        for (int i = 0; i < weights.Length; i++)
        {
            for (int j = 0; j < weights[i].Length; j++)
            {
                // Modifica aleatoriamente os pesos com base na taxa de aprendizado
                weights[i][j] += UnityEngine.Random.Range(-1f, 1f) * this.learningRate;
            }

            for (int j = 0; j < biases[i].Length; j++)
            {
                // Modifica aleatoriamente as biases com base na taxa de aprendizado
                biases[i][j] += UnityEngine.Random.Range(-1f, 1f) * this.learningRate;
            }
        }
    }


    public double[] Predict(double[] input)
    {
        double[] layerOutput = input;

        for (int i = 0; i < weights.Length; i++)
        {
            double[] newLayerOutput = new double[biases[i].Length];

            for (int j = 0; j < biases[i].Length; j++)
            {
                double neuronSum = biases[i][j];

                for (int k = 0; k < layerOutput.Length; k++)
                {
                    neuronSum += layerOutput[k] * weights[i][j * layerOutput.Length + k];
                }

                newLayerOutput[j] = Sigmoid(neuronSum);
            }

            layerOutput = newLayerOutput;
        }
        double[] binaryOutput = new double[layerOutput.Length];

        for (int i = 0; i < layerOutput.Length; i++)
        {
            // Aplicando um limiar para converter os valores em 0 ou 1
            binaryOutput[i] = (layerOutput[i] >= 0.5) ? 1 : 0;
        }

        return binaryOutput;
    }
}
