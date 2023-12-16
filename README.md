![Banner](https://github.com/yuradanyliuk/AutonomousParking/assets/56362999/7a597506-8a39-4713-8796-9ce82856b69b)

## Reinforcement learning for precise car navigation and parking
This project focuses on using reinforcement learning techniques to teach an intelligent agent how to navigate and park a car accurately in various parking scenarios.
It's a part of [my bachelor's thesis](https://drive.google.com/drive/folders/1YK7YRnL6dpJ33humapjptR0H9O5MAja_), majoring in "Information Management Systems and Technologies" at KPI, Ukraine.

## Usage
The primary objective of this project revolves around integrating source code and trained neural networks for the implementation of autonomous parking within Unity games or applications.
Additionally, users can leverage the project to enhance parking models, adapting them to more challenging environments, and refining their accuracy, etc.

## Parking lots
Parking in this project involves the utilization of straightforward parking lots, designed based on specifications from [dimensions.com](https://www.dimensions.com), a reference database for dimensional information.

![ParkingLotsMockupsPreview](https://github.com/yuradanyliuk/AutonomousParking/assets/56362999/1c3759db-2399-4041-9201-e7ec58817018)

The elements of the parking lots were created using Unity's built-in tools. For the cars, ready-made models from the [“Low Poly Soviet Cars Pack”](https://assetstore.unity.com/packages/3d/vehicles/low-poly-soviet-cars-pack-184453) were used.

![ParkingLotsPreview](https://github.com/yuradanyliuk/AutonomousParking/assets/56362999/55ea93fe-ad0d-49ce-9930-14b357e1d2ea)

## Installation
- Clone or download the repository
- Install Unity

### Training neural models
The [helper file](/Assets/MLAgents/Training/Scripts/AutonomousParkingTraining.ipynb) served as a guide for installation and training procedures through Google Colab.
> [!NOTE]
> Regrettably, as of June 2023, this approach has become obsolete due to updates in the Google Colab runtime environment. Consequently, the mentioned workflow is **probably** no longer functional.

An alternative approach is to shift from cloud-based training to a local setup. This transition can provide a more stable and controlled environment, mitigating issues arising from external updates or changes. Consider adapting the training process to local resources for continued efficacy.

To facilitate local model training, installation of the following components is imperative:
1) [Python language](https://www.python.org/downloads)
2) [PyTorch Python package](https://pytorch.org/get-started)
3) [TensorFlow Python package](https://www.tensorflow.org/install)
4) [ML agents Python package](https://pypi.org/project/mlagents)

Following the installation process, validation can be performed by executing the designated command:

    mlagents-learn

Upon successful execution, confirmation of a correctly configured setup is indicated by the appearance of the Unity logo in the console. This signifies readiness to commence model training.
![Confirmation of successful setup with Unity logo](https://github.com/danliukuri/AutonomousParking/assets/56362999/23d001e2-e8e2-4ff6-89f8-9cc51157c3db)

### Demonstration Application
Within the project, a [designated branch](/../create-model-demonstration-app) has been established specifically for a demonstration app, exemplifying the model's capabilities. To acquire the executable file, transition to this specialized branch and proceed with building the application.
> [!WARNING]
> Ensure that the TextMeshPro Essentials package is imported. To accomplish this in Unity, click the button:
> > Window > TextMeshPro > Import TMP Examples and Extras.

![Demonstration app in operation](https://github.com/danliukuri/AutonomousParking/assets/56362999/67bde620-81b7-4cf3-af3c-bc0cd01f15f2)
