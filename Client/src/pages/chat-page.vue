<template>
    <div class="container">
        <div class="row">
            <div class="col-md-8 offset-md-2">
                <div class="chat-container">
                    <div class="message-container">
                        <div class="message-list">
                            <div v-for="message in messages" :key="message.id" class="message-item">
                                <div v-if="message.isHuman" class="message-content human-message">{{ message.content }}</div>
                                <div v-else class="message-content ai-message">{{ message.content }}</div>
                            </div>
                        </div>
                    </div>
                    <div class="input-container">
                        <dx-text-box v-model="userMessage" class="input-box"></dx-text-box>
                        <dx-button text="Send" @click="sendMessage" class="btn-primary"></dx-button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import { defineComponent } from "vue";
    import { DxTextBox, DxButton } from 'devextreme-vue';

    export default defineComponent({
        components: {
            DxTextBox,
            DxButton,
        },
        data() {
            return {
                messages: [],
                userMessage: '',
                apiUrl: "http://localhost:5000/api/ChatAPI",
            };
        },
        methods: {
            async sendMessage() {
                if (this.userMessage.trim() !== '') {
                    // Send the user message to the API endpoint
                    const response = await fetch(this.apiUrl, {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: `"${this.userMessage}"`,
                    });

                    // Retrieve the AI response from the API
                    const data = await response.json();

                    // Add the user message to the chat
                    this.messages.push({
                        id: Date.now(),
                        content: 'Human: ' + this.userMessage,
                        isHuman: true,
                    });

                    // Add the AI response to the chat
                    this.messages.push({
                        id: Date.now() + 1,
                        content: 'AI: ' + data,
                        isHuman: false,
                    });

                    // Clear the user input
                    this.userMessage = '';
                }
            },
        },
    });
</script>

<style scoped>
    .container {
        margin-top: 50px;
    }

    .chat-container {
        border: 1px solid #ddd;
        border-radius: 4px;
        padding: 20px;
    }

    .message-container {
        max-height: 300px;
        overflow-y: auto;
        margin-bottom: 10px;
    }

    .message-list {
        list-style-type: none;
        padding: 0;
        margin: 0;
    }

    .message-item {
        margin-bottom: 10px;
    }

    .message-content {
        padding: 10px;
        border-radius: 4px;
    }

    .human-message {
        background-color: #f0f0f0;
        color: #333;
    }

    .ai-message {
        background-color: #f8f9fa;
        color: #212529;
    }

    .input-container {
        display: flex;
        align-items: center;
    }

    .input-box {
        flex: 1;
        margin-right: 10px;
    }

    .btn-primary {
        background-color: #007bff;
        border-color: #007bff;
    }

        .btn-primary:hover {
            background-color: #0069d9;
            border-color: #0062cc;
        }
</style>
