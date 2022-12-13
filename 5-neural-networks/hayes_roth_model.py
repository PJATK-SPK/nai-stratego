import numpy as np
import tensorflow as tf
import pandas as pd

hayes_roth_data = pd.read_csv('datasets/hayes-roth.csv',
                              names=['Name', 'Hobby', 'Age', 'Educational Level', 'Marital Status', 'Class'])
hayes_roth_train_data = hayes_roth_data.copy()
hayes_roth_train_label = hayes_roth_data.pop('Class')
hayes_roth_train_label = np.array(hayes_roth_train_label)

normalize = tf.keras.layers.Normalization()
normalize.adapt(hayes_roth_train_data)

hayes_roth_model = tf.keras.Sequential([normalize, tf.keras.layers.Dense(128, activation='relu'),
                                        tf.keras.layers.Dense(64, activation='relu'),
                                        tf.keras.layers.Dense(41, activation='softmax')
                                        ])
hayes_roth_model.compile(optimizer='adam',
                         loss='sparse_categorical_crossentropy',
                         metrics=['accuracy']
                         )
hayes_roth_model.fit(hayes_roth_train_data, hayes_roth_train_label, epochs=10)
