# Authors: Sandro Sobczynski, Marcel Pankanin

import tensorflow as tf
import matplotlib.pyplot as plt
from sklearn.metrics import ConfusionMatrixDisplay, confusion_matrix

fashion_mnist_data = tf.keras.datasets.fashion_mnist
(fashion_train_images, fashion_train_labels), (
    fashion_test_images, fashion_test_labels) = fashion_mnist_data.load_data()

fashion_label_names = ["T-shirt/top", "Trouser", "Pullover", "Dress", "Coat", "Sandal", "Shirt", "Sneaker", "Bag",
                       "Ankle boot"]

fashion_train_images = fashion_train_images / 255.0
fashion_test_images = fashion_test_images / 255.0


fashion_model = tf.keras.Sequential([
    tf.keras.layers.Flatten(input_shape=(28, 28)),
    tf.keras.layers.Dense(128, activation='relu'),
    tf.keras.layers.Dense(10)])

fashion_model.compile(optimizer='adam',
                      loss=tf.keras.losses.SparseCategoricalCrossentropy(from_logits=True),
                      metrics=['accuracy'])

fashion_model.fit(fashion_train_images, fashion_train_labels, epochs=10)

y_probs = fashion_model.predict(fashion_test_images)
y_preds = y_probs.argmax(axis=1)
cm = confusion_matrix(y_preds, fashion_test_labels)
disp = ConfusionMatrixDisplay(confusion_matrix=cm, display_labels=fashion_label_names)
fig, ax = plt.subplots(figsize=(10, 10))
disp.plot(ax=ax)
plt.show()
