# Authors: Sandro Sobczynski, Marcel Pankanin

# Neural networks
### Problem & resolution:
```
A neural network is a series of algorithms that endeavors to recognize underlying relationships in a set of data through  
a process that mimics the way the human brain operates. In this sense, neural networks refer to systems of neurons,  
either organic or artificial in nature. In this exercise we've trained neural networks using three datasets 
(cifar10, hayes-roth and fashion mnist). Our models achieved at least 70% accuracy.
```

### Hayes-Roth dataset:
```
Concept learning and the recognition and classification of exemplars.

1. name: distinct for each instance and represented numerically
2. hobby: nominal values ranging between 1 and 3
3. age: nominal values ranging between 1 and 4
4. educational level: nominal values ranging between 1 and 4
5. marital status: nominal values ranging between 1 and 4
6. class: nominal value between 1 and 3
```

### Fashion mnist dataset:
```
Fashion-MNIST is a dataset of Zalando's article images—consisting of a training set of 60,000 examples  
and a test set of 10,000 examples. Each example is a 28x28 grayscale image, associated with a label from 10 classes.

0 T-shirt/top
1 Trouser
2 Pullover
3 Dress
4 Coat
5 Sandal
6 Shirt
7 Sneaker
8 Bag
9 Ankle boot
```

### Cifar10 dataset:
```
The CIFAR-10 dataset consists of 60000 32x32 colour images in 10 classes, with 6000 images per class. There are 50000 
training images and 10000 test images. The dataset is divided into five training batches and one test batch, each with 
10000 images. The test batch contains exactly 1000 randomly-selected images from each class. The training batches
contain the remaining images in random order, but some training batches may contain more images from one class 
than another. Between them, the training batches contain exactly 5000 images from each class. "Animals" present in dataset

0 Airplane
1 Automobile
2 Bird
3 Cat
4 Deer
5 Dog
6 Frog
7 Horse
8 Ship
9 Truck
```

### How to run
Please install:
- Python
- pip3 install -r requirments.txt
- for fashion model execute `python3 fashion_model.py`, 
- for animals model execute `python3 animals_model.py`,
- for hayes roth model execute `python3 hayes_roth__model.py`

### Authors: 
- Sandro Sobczynski (s20600)
- Marcel Pankanin (s21167)