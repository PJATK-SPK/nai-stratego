# Authors: Sandro Sobczynski, Marcel Pankanin

import tensorflow as tf

animals_data = tf.keras.datasets.cifar10

(animals_train_images, animals_train_labels), (animals_test_images, animals_test_labels) = animals_data.load_data()

animals_train_labels = animals_train_labels.reshape(-1, )
animals_test_labels = animals_test_labels.reshape(-1, )

animals_train_images = animals_train_images / 255.0
animals_test_images = animals_test_images / 255.0

animals_model = tf.keras.Sequential([
    tf.keras.layers.Conv2D(filters=32, kernel_size=(3, 3), activation='relu', input_shape=(32, 32, 3)),
    tf.keras.layers.MaxPooling2D((2, 2)),
    tf.keras.layers.Conv2D(filters=64, kernel_size=(3, 3), activation='relu'),
    tf.keras.layers.MaxPooling2D((2, 2)),
    tf.keras.layers.Flatten(),
    tf.keras.layers.Dense(64, activation='relu'),
    tf.keras.layers.Dense(10, activation='softmax')
])

animals_model.compile(optimizer='adam',
                      loss='sparse_categorical_crossentropy',
                      metrics=['accuracy'])

animals_model.fit(animals_train_images, animals_train_labels, epochs=10)
